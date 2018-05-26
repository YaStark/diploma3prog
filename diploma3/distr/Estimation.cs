using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Accord.Statistics.Distributions.Univariate;

namespace diploma3.distr {
	public class Estimation {

		private static class Defaults {
			public const double Alpha = 4;
			public const double Beta = 0.75;
			public const int BatchSize = 1000;
			public const int BatchCount = 200;

			public const double GammaStep = 0.01;
		}
		
		#region Parameter properties

		[DefaultValue(Defaults.Alpha)]
		public double Alpha { get; set; }

		[DefaultValue(Defaults.Beta)]
		public double Beta { get; set; }

		[DefaultValue(Defaults.GammaStep)]
		public double GammaStep { get; set; }

		public int GammaStepCount 
		{
			get { return GammaStep == 0 ? 0 : (int)((GammaMax - GammaMin) / GammaStep + 1.5); }
		}

		public double GammaMin { get; set; }
		public double GammaMax { get; set; }

		/// <summary>
		/// ng
		/// </summary>
		[DefaultValue(Defaults.BatchSize)]
		public int BatchSize { get; set; }

		/// <summary>
		/// ns
		/// </summary>
		[DefaultValue(Defaults.BatchCount)]
		public int BatchCount { get; set; }

		#endregion Parameter properties

		#region Result parameters

		public EstPoint[] Means { get; set; }
		public bool Minus { get; set; }

		#endregion Result parameters

		public Estimation() {
			Alpha = Defaults.Alpha;
			Beta = Defaults.Beta;
			GammaStep = Defaults.GammaStep;

			BatchSize = Defaults.BatchSize;
			BatchCount = Defaults.BatchCount;
		}

		private static void GammaBounds(ref double gammaFrom, ref double gammaTo)
		{
			const double ONE = 1 - 1e-9;
			if (gammaFrom > gammaTo)
			{
				var temp = gammaFrom;
				gammaFrom = gammaTo;
				gammaTo = temp;
			}
			if (gammaFrom < 0)
			{
				gammaFrom = 0;
			}
			if (gammaTo >= ONE)
			{
				gammaTo = ONE;
			}
		}

		private EstPoint[] Est(double gammaFrom, double gammaTo, int steps, bool minus = false)
		{
			EstPoint[] estPoints = new EstPoint[steps];
			GammaBounds(ref gammaFrom, ref gammaTo);
			double step = (gammaTo - gammaFrom) / (steps-1);
			var opts = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 4 };
			double brev = 1.0 / BatchCount;
			Parallel.For(0, steps, opts, g =>
			{
				double gamma = gammaFrom + g * step;
				var distr = new Distribution(Alpha, Beta, gamma, BatchSize);
				double w = 0, d = 0;
				for (int batch = 0; batch < BatchCount; batch++)
				{
					double[] array = minus ? Rnd2(distr, BatchSize) : Rnd(distr, BatchSize);
					double delta = Hill(distr, array) - distr.AlphaRev;
					if ((!minus && delta > distr.Bn) || (minus && delta < -distr.Bn))
					{
						int sign = minus ? -1 : 1;
						double wp = 1;
						for (int k = 0; k < BatchSize; k++)
						{
							wp *= 1 / (1 + sign * distr.Bn * distr.h(array[k]));
						}
						double l = wp * brev;
						w += l;
						d += wp * l;
					}
				}
				double p0 = 1;//NormalDistribution.Standard.InverseDistributionFunction(gamma);
				double sig = p0 * Math.Sqrt((d - w * w) / BatchCount);
				estPoints[g] = new EstPoint(w, sig, gamma);
			});
			return estPoints;
		}

		private EstPoint[] EstBootstrap(double gammaFrom, double gammaTo, int steps, bool minus = false) 
		{
			EstPoint[] estPoints = new EstPoint[steps];
			GammaBounds(ref gammaFrom, ref gammaTo);
			double step = (gammaTo - gammaFrom) / (steps - 1);
			var opts = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 4 };
			Parallel.For(0, steps, opts, g => {
				double gamma = gammaFrom + g * step;
				var distr = new Distribution(Alpha, Beta, gamma, BatchSize);
				Bootstrap bootstrap = new Bootstrap(BatchCount * 50, distr);
				int w = 0;
				for (int batch = 0; batch < BatchCount; batch++)
				{
					double[] array = bootstrap.Next(BatchSize);
					double delta = Hill(distr, array) - distr.AlphaRev;
					if (delta > distr.Bn * distr.Sigma) w++;
				}
				double w0 = (double)w / BatchCount;
				double p1 = Math.Abs(DispSimple(w, BatchCount, gamma, 1) - w0);
				double p2 = Math.Abs(DispSimple(w, BatchCount, gamma, -1) - w0);
				estPoints[g] = new EstPoint(w0, Math.Max(p1, p2), gamma);
			});
			return estPoints;
		}

		private EstPoint[] EstBruteforce(double gammaFrom, double gammaTo, int steps, bool minus = false) {
			EstPoint[] estPoints = new EstPoint[steps];
			GammaBounds(ref gammaFrom, ref gammaTo);
			double step = (gammaTo - gammaFrom) / (steps - 1);
			var opts = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 4 };
			Parallel.For(0, steps, opts, g => {
				double gamma = gammaFrom + g * step;
				var distr = MakeDistr(gamma);
				var rnd2 = new ExponentialDistribution(distr.Alpha);
				int w = 0;
				for (int batch = 0; batch < BatchCount; batch++) {
					double[] array = rnd2.Generate(BatchSize);
					double delta = Hill(distr, array) - distr.AlphaRev;
					if (!minus && delta > distr.Bn || minus && delta < -distr.Bn) w++;
				}
				double w0 = (double)w / BatchCount;
				double p0 = 1;//NormalDistribution.Standard.InverseDistributionFunction(gamma);
				double d = p0 * Math.Sqrt(w0 * (1 - w0) / BatchCount);
				estPoints[g] = new EstPoint(w0, d, gamma);
			});
			return estPoints;
		}

		private static double DispSimple(int m, int n, double gamma, int sign)
		{
			double tb = sign * NormalDistribution.Standard.InverseDistributionFunction(gamma / 2);
			double t = m + 0.5 * tb * tb + tb * Math.Sqrt(m * (1 - (double) m / n) + 0.25 * tb * tb);
			return t / (n + tb * tb);
		}

		public void Run()
		{
			Means = Est(GammaMin, GammaMax, GammaStepCount, Minus);
		}

		public void RunBootstrap()
		{
			Means = EstBootstrap(GammaMin, GammaMax, GammaStepCount, Minus);
		}

		public void RunBruteforce() 
		{
			Means = EstBruteforce(GammaMin, GammaMax, GammaStepCount, Minus);
		}

		public void RunSum()
		{
			int n1 = GammaStepCount / 2;
			var m1 = Est(0, 1, n1); // P(delta > bn)
			var m2 = Est(0, 1, GammaStepCount - n1, true); // P(delta < -bn)
			foreach (EstPoint t in m1) {
				t.Mean = 1 - t.Mean;
			}
			foreach (EstPoint t in m2)
			{
				t.X = -t.X;
			}
			Means = m2.Reverse().Concat(m1).ToArray();
		}

		public Distribution MakeDistr(double gamma)
		{
			return new Distribution(Alpha, Beta, gamma, BatchSize);
		}

		private double Hill(Distribution t, double[] x) {
			Array.Sort(x);
			int m = (int)(t.Beta * t.Ng);
			double s = 0;
			for (int i = m - 1; i < x.Length; i++)
			{
				s += x[i];
			} 
			return s / (t.Ng - m + 1) - x[m - 1];
		}

		private double[] Rnd(Distribution distr, int count)
		{
			return distr.Next(count);
		}

		private double[] Rnd2(Distribution distr, int count)
		{
			return distr.Next2(count);
		}

	}

	public sealed class EstPoint {

		public double Mean { get; set; }
		public double Sigma { get; set; }
		public double X { get; set; }

		public EstPoint(double mean, double sigma, double x = 0) {
			Mean = mean;
			Sigma = sigma;
			X = x;
		}
	}
}
