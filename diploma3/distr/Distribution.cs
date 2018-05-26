using Accord.Statistics.Distributions.Univariate;
using diploma3.distr;
using System;

namespace diploma3 {
	public class Distribution {

		private static ExponentialDistribution _norm = new ExponentialDistribution();
		private static UniformContinuousDistribution _unif = new UniformContinuousDistribution();

		public static double qnorm(double p) { return _norm.InverseDistributionFunction(p); }
		public static double runif(double a, double b) { return a + _unif.Generate() * (b - a); }

		public double Alpha { get; set; }
		public double Beta { get; set; }
		public double Gamma { get; set; }
		public double Ng { get; set; }

		private RndSum rnd;
		private RndSum2 rnd2;

		public Distribution(double alpha, double beta, double gamma, double ng) {
			Alpha = alpha;
			Beta = beta;
			Gamma = gamma;
			Ng = ng;

			AlphaRev = 1 / Alpha;

			X1 = d_rev(Beta);
			X2 = X1 + AlphaRev;
			Sigma = sig();
			Bn = qnorm(Gamma) / Math.Sqrt(Ng) / Sigma;

			rnd = new RndSum(this);
			rnd2 = new RndSum2(this);
		}

		public double[] Next(int count) {
			return rnd.Next(count);
		}

		public double[] Next2(int count) {
			return rnd2.Next(count);
		}

		public double AlphaRev { get; private set; }
		public double X1 { get; private set; }
		public double X2 { get; private set; }
		public double Bn { get; set; }
		public double Sigma { get; private set; }

		private double sig()
		{
			return Math.Sqrt((Beta + 1) / (1 - Beta)) * AlphaRev;
			//return Math.Sqrt((Beta * (2 * Alpha * X1 + 1) + 1) * AlphaRev * AlphaRev / (1 - Beta));
		}

		public double p(double x) { return Alpha * Math.Exp(-x * Alpha); }

		public double d(double x) { return 1 - Math.Exp(-x * Alpha); }

		public double d_rev(double x) { return -Math.Log(1 - x) * AlphaRev; }

		public double[] d_rev(double[] x) {
			double[] res = new double[x.Length];
			for (int i = 0; i < x.Length; i++) {
				res[i] = d_rev(x[i]);
			}
			return res;
		}

		public double h(double x) { return x < X1 ? 0 : (x - X2) / (1 - Beta); }

		public double g(double x) { return p(x) * (1 + Bn * h(x)); }

		// bn < 0:

		public double g2(double x) { return p(x) * (1 - Bn * h(x)); }

	}
}
