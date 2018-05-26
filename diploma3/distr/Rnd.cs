using Accord.Statistics.Distributions.Univariate;
using System;

namespace diploma3.distr
{
	public abstract class RndBase
	{
		protected Distribution T;

		protected RndBase(Distribution t)
		{
			T = t;
		}

		public abstract double Next();

		public virtual double[] Next(int count)
		{
			double[] rnd = new double[count];
			for (int i = 0; i < count; i++)
			{
				rnd[i] = Next();
			}
			return rnd;
		}

		protected double IntG_B(int bnSign = 1)
		{
			return (1 - 1 / Math.E) * (1 - T.Beta) - bnSign * T.Bn * T.AlphaRev / Math.E;
		}

		protected double IntG_C(int bnSign = 1)
		{
			return (1 - T.Beta + bnSign * T.Bn * T.AlphaRev) / Math.E;
		}
	}

	public class RndA : RndBase 
	{
		private readonly UniformContinuousDistribution _unif;

		public RndA(Distribution t)
			: base(t)
		{
			_unif = new UniformContinuousDistribution(0, t.Beta);
		}

		public override double Next()
		{
			return T.d_rev(_unif.Generate());
		}
	}

	public class RndB : RndBase 
	{
		private readonly UniformContinuousDistribution _unif;
		private readonly double _d;

		public RndB(Distribution t)
			: base(t)
		{
			//_d = 1 - t.Bn * t.AlphaRev / (Math.E - 1) / (1 - t.Beta);
			//_d = 1 / _d;
			_d = 1;
			_unif = new UniformContinuousDistribution(t.d(t.X1 * _d), t.d(t.X2 * _d));
		}

		public override double Next() {
			while (true)
			{
				double eta = T.d_rev(_unif.Generate()) / _d;
				if (eta > T.X1 && eta < T.X2)
				{
					double xi = Distribution.runif(0, T.p(eta));
					if (xi < T.g(eta)) return eta;					
				}
			}
		}
	}
	public class RndC : RndBase {
		private readonly GammaDistribution _gamma;
		private readonly UniformContinuousDistribution _unif1;
		private readonly UniformContinuousDistribution _unif2;

		public RndC(Distribution t)
			: base(t)
		{
			//var p1 = t.Bn / Math.E * t.AlphaRev;
			var p1 = t.Bn / (1 - t.Beta) * t.AlphaRev;
			_gamma = new GammaDistribution(t.AlphaRev, 2);
			_unif1 = new UniformContinuousDistribution(t.d(t.X2), 1);
			_unif2 = new UniformContinuousDistribution(0, 1 + p1);
		}

		private double RndC1() 
		{
			return T.d_rev(_unif1.Generate());
		}

		private double RndC2()
		{
			return _gamma.Generate() + T.X2;
		}

		public override double Next()
		{
			if(_unif2.Generate() < 1) return RndC1();
			double rval;
			do
			{
				rval = RndC2();
			}
			while (rval < T.X2);
			return rval;
		}
	}

	public class RndSum : RndBase
	{
		private readonly RndBase _a;
		private readonly RndBase _b;
		private readonly RndBase _c;
		private readonly UniformContinuousDistribution _unif;
		private readonly double _p2;

		public RndSum(Distribution t)
			: base(t)
		{
			_a = new RndA(t);
			_b = new RndB(t);
			_c = new RndC(t);
			_p2 = 1 - (1 - t.Beta) / Math.E - t.Bn * t.AlphaRev / Math.E;
			//t.Beta + (Math.E - 1) * (1 - t.Beta) / Math.E - t.Bn * t.AlphaRev / Math.E;
			_unif = new UniformContinuousDistribution(0, 1);
		}

		public override double Next()
		{
			double rnd = _unif.Generate();
			return rnd < T.Beta ? _a.Next() : (rnd > _p2 ? _c.Next() : _b.Next());
		}
	}

	// bn < 0 : 

	public class RndB2 : RndBase
	{
		private readonly GammaDistribution _gamma;
		private readonly UniformContinuousDistribution _unif1;
		private readonly UniformContinuousDistribution _unif2;

		public RndB2(Distribution t)
			: base(t)
		{
			_gamma = new GammaDistribution(t.AlphaRev, 2);
			_unif1 = new UniformContinuousDistribution(T.Beta, T.d(T.X2));
			double cxn = 1 + t.Bn * t.AlphaRev / Math.E;
			_unif2 = new UniformContinuousDistribution(0, cxn);
		}
		
		private double Rnd1()
		{
			return T.d_rev(_unif1.Generate());
		}

		private double Rnd2()
		{
			while (true)
			{
				double rval = _gamma.Generate();
				if (rval < T.X2 - T.X1) return T.X2 - rval;
			}
		}

		public override double Next()
		{
			return _unif2.Generate() < 1 ? Rnd1() : Rnd2();
		}
	}

	public class RndB2_2 : RndBase
	{
		private readonly UniformContinuousDistribution _unif;
		private readonly double _coeff;

		public RndB2_2(Distribution t)
			: base(t)
		{
			_coeff = 1 + T.Bn * T.AlphaRev / (1 - T.Beta);
			_unif = new UniformContinuousDistribution(T.Beta, T.d(t.X2));
		}

		public override double Next()
		{
			while (true)
			{
				double eta = T.d_rev(_unif.Generate());
				double xi = Distribution.runif(0, T.p(eta) * _coeff);
				if (xi <= T.g2(eta)) return eta;
			}
		}
	}

	public class RndC2 : RndBase
	{
		private readonly UniformContinuousDistribution _unif;

		public RndC2(Distribution t)
			: base(t)
		{
			_unif = new UniformContinuousDistribution(T.d(t.X2), 1);
		}

		public override double Next()
		{
			while (true)
			{
				double eta = T.d_rev(_unif.Generate());
				double xi = Distribution.runif(0, T.p(eta));
				if (xi <= T.g2(eta)) return eta;
			}
		}
	}

	public class RndSum2 : RndBase {
		private readonly RndBase _a;
		private readonly RndBase _b;
		private readonly RndBase _c;
		private readonly UniformContinuousDistribution _unif;
		private readonly double _sg1;
		private readonly double _sg2;

		public RndSum2(Distribution t)
			: base(t) {
			_a = new RndA(t);
			_b = new RndB2_2(t);
			_c = new RndC2(t);
			_sg1 = t.Beta;
			_sg2 = _sg1 + IntG_B(-1);
			_unif = new UniformContinuousDistribution(0, 1);
		}

		public override double Next()
		{
			double eta = _unif.Generate();
			return eta < _sg1 ? _a.Next() : eta < _sg2 ? _b.Next() : _c.Next();
		}
	}
}
