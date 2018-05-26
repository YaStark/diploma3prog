using System.Collections.Generic;
using System.Linq;
using Accord.Math;
using Accord.Statistics.Distributions.Univariate;
using diploma3.utils.tree;

namespace diploma3.distr {
	class Bootstrap : IComparer<Bootstrap.Node> {

		public int N { get; private set; }

		public double[] X { get; private set; }

		public double[] Probabilities { get; private set; }

		private readonly double _nRev;

		private readonly Distribution _distr;

		private readonly BST _tree;

		public Bootstrap(int n, Distribution distr)
		{
			N = n;
			_distr = distr;
			_nRev = 1.0 / N;
			var unif = new UniformContinuousDistribution();
			X = distr.d_rev(unif.Generate(N)).OrderBy(x => x).ToArray();
			Probabilities = X.Select(GetProbailities).ToArray().CumulativeSum();
			_tree = new BST();
			for (int i = 0; i < Probabilities.Length; i++)
			{
				_tree.Add(Probabilities[i], X[i]);
			}
		}

		public double[] Next(int n)
		{
			return Random(n);
		}

		private double[] Random(int samples)
		{
			double[] probabilites = new double[samples];
			for (int i = 0; i < probabilites.Length; ++i)
			{
				probabilites[i] = Tools.Random.NextDouble();
			}
			double[] values = new double[samples];
			for (int i = 0; i < values.Length; ++i)
			{
				if (probabilites[i] < Probabilities[0])
				{
					values[i] = X[0];
				}
				else
				{
					values[i] = _tree.GetLowerOrEqual(probabilites[i]);
				}
			}
			return values;
		}

		private double GetProbailities(double x)
		{
			if (x < _distr.X1)
			{
				return _nRev;
			}
			return _nRev * (1 + _distr.Bn * (x - _distr.X2) / (1 - _distr.Beta) / _distr.Sigma);
		}

		public int Compare(Node x, Node y)
		{
			return x.Weight.CompareTo(y.Weight);
		}

		internal struct Node
		{
			public double Weight;
			public double Value;
			public Node( double weight, double value) : this()
			{
				Value = value;
				Weight = weight;
			}
		}
	}
}
