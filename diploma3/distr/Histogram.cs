using System;
using System.Diagnostics;

namespace diploma3.distr
{
	public static class Histogram
	{
		public static int[] Data(RndBase rnd, int n, double min, double max, int sections = 250)
		{
			int[] data = new int[sections];
			for (int i = 0; i < n; i++)
			{
				double val;
				do
				{
					val = rnd.Next();
				}
				while (val < min || val > max);
				int section = (int) ((val - min) / (max - min) * sections);
				data[section]++;
			}
			return data;
		}

		public static void DataAsync(RndBase rnd, double min, double max, int sections, Action<int[]> updateAction,
			Func<bool> cancelAction)
		{
			int[] data = new int[sections];
			double df = sections / (max - min);
			Stopwatch sw = new Stopwatch();
			sw.Start();
			while (true)
			{
				double val;
				do {
					val = rnd.Next();
					if (!cancelAction()) return;
				}
				while (val < min || val > max);
				if (sw.Elapsed.Milliseconds > 100)
				{
					updateAction(data);
					sw.Restart();
				}
				int section = (int)((val - min) * df);
				data[section]++;
			}
		}
	}
}
