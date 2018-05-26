using diploma3.distr;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace diploma3 {
	public partial class Form1 : Form
	{
		private readonly Estimation _est = new Estimation
		{
			Alpha = 2,
			Beta = 0.85,
			BatchSize = 1000,
			BatchCount = 10000, 
			GammaStep = 0.1/15,
			GammaMax = 1,
			GammaMin = 0.9
		};

		public Form1()
		{
			InitializeComponent();

			tboxGammaFrom.Value = (decimal)_est.GammaMin;
			tboxGammaTo.Value = (decimal)_est.GammaMax;
			tboxGammaCount.Value = _est.GammaStepCount;
			tboxAlpha.Value = (decimal)_est.Alpha;
			tboxBeta.Value = (decimal)_est.Beta;
			tboxBatchSize.Value = _est.BatchSize;
			tboxBatchCount.Value = _est.BatchCount;
		}

		private void ResetChart()
		{
			chart.ResetAutoValues();
			chart.ChartAreas[0].AxisX.Minimum = Double.NaN;
			chart.ChartAreas[0].AxisX.Maximum = Double.NaN;
			chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
			chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
			chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
		}

		private void CreateGraph(string title)
		{
			ResetChart();
			Series series = new Series(title + " σ") {
				IsVisibleInLegend = false,
				ChartType = SeriesChartType.ErrorBar
			};

			Series series2 = new Series(title + ", ± σ") {
				ChartType = SeriesChartType.FastLine
			};

			Console.WriteLine("------------");
			foreach (EstPoint t in _est.Means) {
				double s = t.Sigma, m = t.Mean, x = t.X;
				double[] y = { m, m - s, m + s };

				series.Points.Add(new DataPoint(x, y));
				series2.Points.Add(new DataPoint(x, m));
			}
			double sigmaMean = _est.Means.Select(x => x.Sigma).Sum() / _est.Means.Length;
			Console.WriteLine("Sigma: {0}", sigmaMean);
			chart.ChartAreas[0].AxisX.Interval = _est.GammaStep;
			chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0.0###}";
			chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;

			if (chart.Series.Any(x => x.Name == series2.Name)) chart.Series[series2.Name] = series2;
			else chart.Series.Add(series2);
			if (chart.Series.Any(x => x.Name == series.Name)) chart.Series[series.Name] = series;
			else chart.Series.Add(series);
		}

		private void ShowHistogram(Func<double, double> p, Func<double, double> g, int[] data, double min, double max)
		{
			ResetChart();
			chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			chart.ChartAreas[0].AxisY.Minimum = 0;
			Series series = new Series("Histogram") {
				ChartType = SeriesChartType.Column,
				Color = Color.Gray
			};
			Series seriesP = new Series("p(x)") {
				ChartType = SeriesChartType.Line,
				Color = Color.Blue,
			};
			Series seriesG = new Series("g(x)") {
				ChartType = SeriesChartType.Line,
				Color = Color.Green,
			};

			double step = (max - min) / data.Length;
			for (int i = 0; i < data.Length; i++) {
				double x = Math.Round(step * i + min, 3);
				series.Points.Add(new DataPoint(x, data[i]));
			}

			double scaleP = data[0] / g(min);
			step = (max - min) / 500;
			for (int j = 0; j < 500; j++) {
				double x = Math.Round(step * j + min, 3);
				seriesP.Points.Add(new DataPoint(x, p(x) * scaleP));
				seriesG.Points.Add(new DataPoint(x, g(x) * scaleP));

			}
			chart.Series.Clear();
			chart.Series.Add(series);
			chart.Series.Add(seriesP);
			chart.Series.Add(seriesG);

			Series seriesLine = new Series("X1, X2") {
				ChartType = SeriesChartType.Point,
				Color = Color.Red,
				BorderWidth = 2,
			};
			var distr = _est.MakeDistr(0.95);
			seriesLine.Points.AddXY(distr.X1, p(distr.X1));
			seriesLine.Points.AddXY(distr.X1, g(distr.X1));
			seriesLine.Points.AddXY(distr.X2, p(distr.X2));
			seriesLine.Points.AddXY(distr.X2, g(distr.X2));
			//chart1.Series.Add(seriesLine);
			Refresh();
		}

		private async void CreateHistogram(RndBase rnd, Func<double, double> p, Func<double, double> g) 
		{
			double min = (double)tboxHistFrom.Value;
			double max = (double)tboxHistTo.Value;
			int sections = (int) tboxHistCount.Value;

			if (cbHistInteractive.Checked)
			{
				var form = new FormInteractiveHist();
				form.Show(this);
				await Task.Factory.StartNew(
					() =>
						Histogram.DataAsync(rnd, min, max, sections, x =>
						{
							BeginInvoke((Action) (() =>
							{
								form.SampleSize = x.Sum();
								ShowHistogram(p, g, x, min, max);
							}));
						}, () => form.Stop));
			}
			else
			{
				var histData = Histogram.Data(rnd, (int)tboxHistSampleSize.Value, min, max, sections);
				ShowHistogram(p, g, histData, min, max);
			}
		}

		private async void chart1_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				chart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
			}
		}

		private void SetChartBounds()
		{
			chart.ChartAreas[0].AxisX.Minimum = _est.GammaMin - _est.GammaStep;
			chart.ChartAreas[0].AxisX.Maximum = _est.GammaMax + _est.GammaStep;
		}

		private void toolStripButton3_Click(object sender, EventArgs e) {
			SetParams();
			Distribution distr = _est.MakeDistr(0.95);
			CreateHistogram(new RndSum(distr), distr.p, distr.g);
		}

		private void toolStripButton4_Click(object sender, EventArgs e) {
			SetParams();
			Distribution distr = _est.MakeDistr(0.95);
			CreateHistogram(new RndSum2(distr), distr.p, distr.g2);
		}

		private async void toolStripButton5_Click(object sender, EventArgs e) 
		{
			chart.Series.Clear();
			Stopwatch sw = new Stopwatch();
			sw.Start();
			_est.Minus = false;
			await Task.Factory.StartNew(_est.Run);
			CreateGraph2(" (bn > 0)");
			_est.Minus = true;
			await Task.Factory.StartNew(_est.Run);
			sw.Stop();
			lblInfo.Text = sw.Elapsed.ToString();
			CreateGraph2(" (bn < 0)");

			chart.ChartAreas[0].AxisX.Minimum = -1;
			chart.ChartAreas[0].AxisX.Maximum = 1;
			chart.ChartAreas[0].AxisY.Minimum = 0;
			chart.ChartAreas[0].AxisY.Maximum = 1;
		}

		private void CreateGraph2(string prefix)
		{
			Series series = new Series("w est" + prefix)
			{
				ChartType = SeriesChartType.ErrorBar,
				Color = Color.DarkRed,
				BorderWidth = 2,
			};

			Series series2 = new Series("w means line" + prefix) {
				ChartType = SeriesChartType.FastLine
			};

			foreach (EstPoint t in _est.Means) {
				double s = t.Sigma;
				double m = t.Mean;
				series.Points.Add(new DataPoint(t.X, new []{ m, m - s, m + s }));
				series2.Points.Add(new DataPoint(t.X, m));
			}

			chart.Series.Add(series);
			chart.Series.Add(series2);
		}

		private void OnBnPlus(object sender, EventArgs e)
		{
			SetParams();
			_est.Minus = false;
			if (sender == bruteforceToolStripMenuItem)
			{
				Run(_est.RunBruteforce, "Direct");
			} 
			else if (sender == bootstrapToolStripMenuItem) 
			{
				Run(_est.RunBootstrap, "Bootstrap");
			}
			else
			{
				Run(_est.Run, "Importance");
			}
		}

		private void OnBnMinus(object sender, EventArgs e) 
		{
			SetParams();
			_est.Minus = true;
			if (sender == bruteforceToolStripMenuItem1) {
				Run(_est.RunBruteforce, "Direct");
			} else {
				Run(_est.Run, "Importance");
			}
		}

		private async void Run(Action task, string title)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			await Task.Factory.StartNew(task);
			sw.Stop();
			lblInfo.Text = sw.Elapsed.ToString();
			CreateGraph(title);
			SetChartBounds();
		}

		private void OnClear(object sender, EventArgs e) {
			chart.Series.Clear();
		}

		private async void bruteforceToolStripMenuItem2_Click(object sender, EventArgs ea) 
		{
			await Task.Factory.StartNew(() => SigmaX("sigma.csv", "Method1", e => e.Run()))
				.ContinueWith(_ => Thread.Sleep(100))
				.ContinueWith(_ => SigmaX("sigma.csv", "Direct0", e => e.RunBruteforce()))
				.ContinueWith(_ => Thread.Sleep(100));
		}

		private void CreateImgInfo(string fileName, string name, Action runAction, bool minus)
		{
			chart.Series.Clear();
			_est.Minus = minus;
			Run(runAction, name);
			chart.SaveImage(fileName + ".png", ChartImageFormat.Png);
			using (var stream = File.CreateText(fileName + ".txt")) {
				stream.WriteLine("Gamma; Omega; Sigma");
				foreach (var est in _est.Means) stream.WriteLine("{0}; {1}; {2}", est.X, est.Mean, est.Sigma);
				stream.Flush();
			}			
		}

		private void SigmaX(string fileName, string methodName, Action<Estimation> action)
		{
			// alpha  = 1,2,3,4,5,10
			// beta   = 0.7:0.95 / 0.05 (6)
			// gamma  = 0.8:0.98 / 0.02 (10)
			if (!File.Exists(fileName)) {
				using (var stream = File.Create(fileName)) {
					var writer = new StreamWriter(stream);
					writer.WriteLine("Time; Method; Alpha; Beta; BatchCount; Gamma; Sigma");
					writer.Flush();
				}
			}
			int[] alpha = {1, 2, 3, 4, 5, 10};
			int[] cnts = {1000};//100, 200, 500, 1000, 2000, 5000, 10000 };
			int count = 0;
			int max = alpha.Length * cnts.Length * 6 * 10;
			for (int ia = 0; ia < alpha.Length; ia++)
			{
				double beta = 0.7;
				while (beta < 0.97) {
					for (int bcount = 0; bcount < cnts.Length; bcount++) {
						double gamma = 0.8;
						while (gamma < 0.995) {
							Estimation est = new Estimation {
								Alpha = alpha[ia],
								Beta = beta,
								BatchSize = 500,
								BatchCount = cnts[bcount],
								GammaMin = gamma
							};
							action(est);
							SigmaIteration(fileName, methodName, est);
							lblInfo.Text = string.Format("{2}:{0}/{1}", count, max, methodName);
							count++;
							gamma += 0.02;
						}
					}
					beta += 0.05;
				}
				
			}

		}

		private static void SigmaIteration(string fileName, string methodName, Estimation est)
		{
			using (var fileStream = File.Open(fileName, FileMode.Append))
			{
				var writer = new StreamWriter(fileStream);
				double sMean = est.Means.Sum(x => x.Sigma) / est.BatchCount;
				writer.WriteLine("{0}; {1}; {2}; {3:0.00}; {4}; {5:0.00}; {6:g}",
					DateTime.Now, methodName, est.Alpha, est.Beta, est.BatchCount, est.GammaMin, sMean);
				writer.Flush();
			}
		}

		private void ValidateGamma(object sender, EventArgs e)
		{
			if (sender == tboxGammaFrom)
			{
				tboxGammaTo.Minimum = tboxGammaFrom.Value + (decimal)0.001;
			}
			else
			{
				tboxGammaFrom.Maximum = tboxGammaTo.Value - (decimal)0.001;
			}
		}

		private void VaildateHist(object sender, EventArgs e)
		{
			if (sender == tboxHistFrom)
			{
				tboxHistTo.Minimum = tboxHistFrom.Value + (decimal)0.001;
			}
			else
			{
				tboxHistFrom.Maximum = tboxHistTo.Value - (decimal)0.001;
			}
		}

		private void SetParams()
		{
			_est.Alpha = (double) tboxAlpha.Value;
			_est.Beta = (double)tboxBeta.Value;
			_est.BatchCount = (int)tboxBatchCount.Value;
			_est.BatchSize = (int) tboxBatchSize.Value;
			_est.GammaMin = (double) tboxGammaFrom.Value;
			_est.GammaMax = (double) tboxGammaTo.Value;
			_est.GammaStep = (_est.GammaMax - _est.GammaMin) / (int)tboxGammaCount.Value;
		}

		private void OnExportCsv(object sender, EventArgs e) {
			var form = new SaveFileDialog();
			form.Filter = "Csv|*.csv";
			if (form.ShowDialog() == DialogResult.OK)
			{
				using (var stream = form.OpenFile()) {
					var writer = new StreamWriter(stream);
					writer.WriteLine("Gamma; Omega; Sigma");
					foreach (var est in _est.Means) writer.WriteLine("{0}; {1}; {2}", est.X, est.Mean, est.Sigma);
					writer.Flush();
				}							
			}
		}
	}
}
