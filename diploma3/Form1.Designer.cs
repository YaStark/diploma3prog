namespace diploma3 {
	partial class Form1 {
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.bruteforceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bootstrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.method1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.bruteforceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.method1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSigma = new System.Windows.Forms.ToolStripDropDownButton();
			this.bruteforceToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.lblInfo = new System.Windows.Forms.ToolStripLabel();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnClear = new System.Windows.Forms.ToolStripButton();
			this.groupBoxOpts = new System.Windows.Forms.GroupBox();
			this.groupBoxHist = new System.Windows.Forms.GroupBox();
			this.tboxHistTo = new System.Windows.Forms.NumericUpDown();
			this.tboxHistFrom = new System.Windows.Forms.NumericUpDown();
			this.tboxHistCount = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBoxGamma = new System.Windows.Forms.GroupBox();
			this.lblGammaStep = new System.Windows.Forms.Label();
			this.lblGammaTo = new System.Windows.Forms.Label();
			this.tboxGammaFrom = new System.Windows.Forms.NumericUpDown();
			this.tboxGammaCount = new System.Windows.Forms.NumericUpDown();
			this.tboxGammaTo = new System.Windows.Forms.NumericUpDown();
			this.lblGammaFrom = new System.Windows.Forms.Label();
			this.tboxBatchSize = new System.Windows.Forms.NumericUpDown();
			this.tboxBatchCount = new System.Windows.Forms.NumericUpDown();
			this.lblBatchSize = new System.Windows.Forms.Label();
			this.lblBatchCount = new System.Windows.Forms.Label();
			this.tboxBeta = new System.Windows.Forms.NumericUpDown();
			this.lblBeta = new System.Windows.Forms.Label();
			this.tboxAlpha = new System.Windows.Forms.NumericUpDown();
			this.lblAlpha = new System.Windows.Forms.Label();
			this.cbHistInteractive = new System.Windows.Forms.CheckBox();
			this.tboxHistSampleSize = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.btnCsv = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.groupBoxOpts.SuspendLayout();
			this.groupBoxHist.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tboxHistTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxHistFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxHistCount)).BeginInit();
			this.groupBoxGamma.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tboxGammaFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxGammaCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxGammaTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxBatchSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxBatchCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxBeta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxAlpha)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxHistSampleSize)).BeginInit();
			this.SuspendLayout();
			// 
			// chart
			// 
			chartArea2.Name = "ChartArea1";
			this.chart.ChartAreas.Add(chartArea2);
			this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend2.Name = "Legend1";
			this.chart.Legends.Add(legend2);
			this.chart.Location = new System.Drawing.Point(0, 25);
			this.chart.Name = "chart";
			series2.ChartArea = "ChartArea1";
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			this.chart.Series.Add(series2);
			this.chart.Size = new System.Drawing.Size(633, 406);
			this.chart.TabIndex = 1;
			this.chart.Text = "chart1";
			this.chart.Click += new System.EventHandler(this.chart1_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "png|*.png";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.btnSigma,
            this.toolStripButton3,
            this.toolStripButton4,
            this.lblInfo,
            this.toolStripButton5,
            this.btnCsv,
            this.toolStripSeparator1,
            this.btnClear});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bruteforceToolStripMenuItem,
            this.bootstrapToolStripMenuItem,
            this.method1ToolStripMenuItem});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
			this.toolStripDropDownButton1.Text = "+ bn";
			// 
			// bruteforceToolStripMenuItem
			// 
			this.bruteforceToolStripMenuItem.Name = "bruteforceToolStripMenuItem";
			this.bruteforceToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.bruteforceToolStripMenuItem.Text = "Bruteforce";
			this.bruteforceToolStripMenuItem.Click += new System.EventHandler(this.OnBnPlus);
			// 
			// bootstrapToolStripMenuItem
			// 
			this.bootstrapToolStripMenuItem.Name = "bootstrapToolStripMenuItem";
			this.bootstrapToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.bootstrapToolStripMenuItem.Text = "Bootstrap";
			this.bootstrapToolStripMenuItem.Click += new System.EventHandler(this.OnBnPlus);
			// 
			// method1ToolStripMenuItem
			// 
			this.method1ToolStripMenuItem.Name = "method1ToolStripMenuItem";
			this.method1ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.method1ToolStripMenuItem.Text = "Method 1";
			this.method1ToolStripMenuItem.Click += new System.EventHandler(this.OnBnPlus);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bruteforceToolStripMenuItem1,
            this.method1ToolStripMenuItem1});
			this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
			this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(42, 22);
			this.toolStripDropDownButton2.Text = "- bn";
			// 
			// bruteforceToolStripMenuItem1
			// 
			this.bruteforceToolStripMenuItem1.Name = "bruteforceToolStripMenuItem1";
			this.bruteforceToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
			this.bruteforceToolStripMenuItem1.Text = "Bruteforce";
			this.bruteforceToolStripMenuItem1.Click += new System.EventHandler(this.OnBnMinus);
			// 
			// method1ToolStripMenuItem1
			// 
			this.method1ToolStripMenuItem1.Name = "method1ToolStripMenuItem1";
			this.method1ToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
			this.method1ToolStripMenuItem1.Text = "Method 1";
			this.method1ToolStripMenuItem1.Click += new System.EventHandler(this.OnBnMinus);
			// 
			// btnSigma
			// 
			this.btnSigma.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnSigma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bruteforceToolStripMenuItem2});
			this.btnSigma.Image = ((System.Drawing.Image)(resources.GetObject("btnSigma.Image")));
			this.btnSigma.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSigma.Name = "btnSigma";
			this.btnSigma.Size = new System.Drawing.Size(53, 22);
			this.btnSigma.Text = "Sigma";
			// 
			// bruteforceToolStripMenuItem2
			// 
			this.bruteforceToolStripMenuItem2.Name = "bruteforceToolStripMenuItem2";
			this.bruteforceToolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
			this.bruteforceToolStripMenuItem2.Text = "Bruteforce";
			this.bruteforceToolStripMenuItem2.Click += new System.EventHandler(this.bruteforceToolStripMenuItem2_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(73, 22);
			this.toolStripButton3.Text = "Hist +bn";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(70, 22);
			this.toolStripButton4.Text = "Hist -bn";
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(49, 22);
			this.lblInfo.Text = "00:00:00";
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(25, 22);
			this.toolStripButton5.Text = "bn";
			this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnClear
			// 
			this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
			this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(38, 22);
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new System.EventHandler(this.OnClear);
			// 
			// groupBoxOpts
			// 
			this.groupBoxOpts.Controls.Add(this.groupBoxHist);
			this.groupBoxOpts.Controls.Add(this.groupBoxGamma);
			this.groupBoxOpts.Controls.Add(this.tboxBatchSize);
			this.groupBoxOpts.Controls.Add(this.tboxBatchCount);
			this.groupBoxOpts.Controls.Add(this.lblBatchSize);
			this.groupBoxOpts.Controls.Add(this.lblBatchCount);
			this.groupBoxOpts.Controls.Add(this.tboxBeta);
			this.groupBoxOpts.Controls.Add(this.lblBeta);
			this.groupBoxOpts.Controls.Add(this.tboxAlpha);
			this.groupBoxOpts.Controls.Add(this.lblAlpha);
			this.groupBoxOpts.Dock = System.Windows.Forms.DockStyle.Right;
			this.groupBoxOpts.Location = new System.Drawing.Point(633, 25);
			this.groupBoxOpts.Name = "groupBoxOpts";
			this.groupBoxOpts.Size = new System.Drawing.Size(167, 406);
			this.groupBoxOpts.TabIndex = 3;
			this.groupBoxOpts.TabStop = false;
			this.groupBoxOpts.Text = "Parameters";
			// 
			// groupBoxHist
			// 
			this.groupBoxHist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxHist.Controls.Add(this.tboxHistSampleSize);
			this.groupBoxHist.Controls.Add(this.label4);
			this.groupBoxHist.Controls.Add(this.cbHistInteractive);
			this.groupBoxHist.Controls.Add(this.tboxHistTo);
			this.groupBoxHist.Controls.Add(this.tboxHistFrom);
			this.groupBoxHist.Controls.Add(this.tboxHistCount);
			this.groupBoxHist.Controls.Add(this.label3);
			this.groupBoxHist.Controls.Add(this.label2);
			this.groupBoxHist.Controls.Add(this.label1);
			this.groupBoxHist.Location = new System.Drawing.Point(4, 214);
			this.groupBoxHist.Name = "groupBoxHist";
			this.groupBoxHist.Size = new System.Drawing.Size(157, 165);
			this.groupBoxHist.TabIndex = 14;
			this.groupBoxHist.TabStop = false;
			this.groupBoxHist.Text = "Histogram";
			// 
			// tboxHistTo
			// 
			this.tboxHistTo.DecimalPlaces = 3;
			this.tboxHistTo.Location = new System.Drawing.Point(86, 79);
			this.tboxHistTo.Margin = new System.Windows.Forms.Padding(5);
			this.tboxHistTo.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.tboxHistTo.Name = "tboxHistTo";
			this.tboxHistTo.Size = new System.Drawing.Size(65, 20);
			this.tboxHistTo.TabIndex = 15;
			this.tboxHistTo.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.tboxHistTo.ValueChanged += new System.EventHandler(this.VaildateHist);
			// 
			// tboxHistFrom
			// 
			this.tboxHistFrom.DecimalPlaces = 3;
			this.tboxHistFrom.Location = new System.Drawing.Point(86, 49);
			this.tboxHistFrom.Margin = new System.Windows.Forms.Padding(5);
			this.tboxHistFrom.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.tboxHistFrom.Name = "tboxHistFrom";
			this.tboxHistFrom.Size = new System.Drawing.Size(65, 20);
			this.tboxHistFrom.TabIndex = 14;
			// 
			// tboxHistCount
			// 
			this.tboxHistCount.Location = new System.Drawing.Point(86, 19);
			this.tboxHistCount.Margin = new System.Windows.Forms.Padding(5);
			this.tboxHistCount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.tboxHistCount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.tboxHistCount.Name = "tboxHistCount";
			this.tboxHistCount.Size = new System.Drawing.Size(65, 20);
			this.tboxHistCount.TabIndex = 13;
			this.tboxHistCount.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 81);
			this.label3.Margin = new System.Windows.Forms.Padding(5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "To";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 51);
			this.label2.Margin = new System.Windows.Forms.Padding(5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "From";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 21);
			this.label1.Margin = new System.Windows.Forms.Padding(5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Count";
			// 
			// groupBoxGamma
			// 
			this.groupBoxGamma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxGamma.Controls.Add(this.lblGammaStep);
			this.groupBoxGamma.Controls.Add(this.lblGammaTo);
			this.groupBoxGamma.Controls.Add(this.tboxGammaFrom);
			this.groupBoxGamma.Controls.Add(this.tboxGammaCount);
			this.groupBoxGamma.Controls.Add(this.tboxGammaTo);
			this.groupBoxGamma.Controls.Add(this.lblGammaFrom);
			this.groupBoxGamma.Location = new System.Drawing.Point(4, 71);
			this.groupBoxGamma.Name = "groupBoxGamma";
			this.groupBoxGamma.Size = new System.Drawing.Size(157, 86);
			this.groupBoxGamma.TabIndex = 13;
			this.groupBoxGamma.TabStop = false;
			this.groupBoxGamma.Text = "γ";
			// 
			// lblGammaStep
			// 
			this.lblGammaStep.Location = new System.Drawing.Point(4, 63);
			this.lblGammaStep.Margin = new System.Windows.Forms.Padding(5);
			this.lblGammaStep.Name = "lblGammaStep";
			this.lblGammaStep.Size = new System.Drawing.Size(68, 13);
			this.lblGammaStep.TabIndex = 14;
			this.lblGammaStep.Text = "Step";
			// 
			// lblGammaTo
			// 
			this.lblGammaTo.Location = new System.Drawing.Point(81, 18);
			this.lblGammaTo.Margin = new System.Windows.Forms.Padding(5);
			this.lblGammaTo.Name = "lblGammaTo";
			this.lblGammaTo.Size = new System.Drawing.Size(68, 13);
			this.lblGammaTo.TabIndex = 13;
			this.lblGammaTo.Text = "To";
			this.lblGammaTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tboxGammaFrom
			// 
			this.tboxGammaFrom.DecimalPlaces = 2;
			this.tboxGammaFrom.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.tboxGammaFrom.Location = new System.Drawing.Point(6, 31);
			this.tboxGammaFrom.Margin = new System.Windows.Forms.Padding(5);
			this.tboxGammaFrom.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tboxGammaFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.tboxGammaFrom.Name = "tboxGammaFrom";
			this.tboxGammaFrom.Size = new System.Drawing.Size(65, 20);
			this.tboxGammaFrom.TabIndex = 6;
			this.tboxGammaFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tboxGammaFrom.ValueChanged += new System.EventHandler(this.ValidateGamma);
			// 
			// tboxGammaCount
			// 
			this.tboxGammaCount.Location = new System.Drawing.Point(86, 61);
			this.tboxGammaCount.Margin = new System.Windows.Forms.Padding(5);
			this.tboxGammaCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.tboxGammaCount.Name = "tboxGammaCount";
			this.tboxGammaCount.Size = new System.Drawing.Size(65, 20);
			this.tboxGammaCount.TabIndex = 12;
			this.tboxGammaCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// tboxGammaTo
			// 
			this.tboxGammaTo.DecimalPlaces = 2;
			this.tboxGammaTo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.tboxGammaTo.Location = new System.Drawing.Point(86, 31);
			this.tboxGammaTo.Margin = new System.Windows.Forms.Padding(5);
			this.tboxGammaTo.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tboxGammaTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.tboxGammaTo.Name = "tboxGammaTo";
			this.tboxGammaTo.Size = new System.Drawing.Size(65, 20);
			this.tboxGammaTo.TabIndex = 11;
			this.tboxGammaTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tboxGammaTo.ValueChanged += new System.EventHandler(this.ValidateGamma);
			// 
			// lblGammaFrom
			// 
			this.lblGammaFrom.Location = new System.Drawing.Point(8, 18);
			this.lblGammaFrom.Margin = new System.Windows.Forms.Padding(5);
			this.lblGammaFrom.Name = "lblGammaFrom";
			this.lblGammaFrom.Size = new System.Drawing.Size(66, 13);
			this.lblGammaFrom.TabIndex = 5;
			this.lblGammaFrom.Text = "From";
			this.lblGammaFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tboxBatchSize
			// 
			this.tboxBatchSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tboxBatchSize.Location = new System.Drawing.Point(90, 192);
			this.tboxBatchSize.Margin = new System.Windows.Forms.Padding(5);
			this.tboxBatchSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.tboxBatchSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.tboxBatchSize.Name = "tboxBatchSize";
			this.tboxBatchSize.Size = new System.Drawing.Size(65, 20);
			this.tboxBatchSize.TabIndex = 10;
			this.tboxBatchSize.ThousandsSeparator = true;
			this.tboxBatchSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// tboxBatchCount
			// 
			this.tboxBatchCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tboxBatchCount.Location = new System.Drawing.Point(90, 162);
			this.tboxBatchCount.Margin = new System.Windows.Forms.Padding(5);
			this.tboxBatchCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.tboxBatchCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tboxBatchCount.Name = "tboxBatchCount";
			this.tboxBatchCount.Size = new System.Drawing.Size(65, 20);
			this.tboxBatchCount.TabIndex = 9;
			this.tboxBatchCount.ThousandsSeparator = true;
			this.tboxBatchCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// lblBatchSize
			// 
			this.lblBatchSize.AutoSize = true;
			this.lblBatchSize.Location = new System.Drawing.Point(8, 194);
			this.lblBatchSize.Margin = new System.Windows.Forms.Padding(5);
			this.lblBatchSize.Name = "lblBatchSize";
			this.lblBatchSize.Size = new System.Drawing.Size(70, 13);
			this.lblBatchSize.TabIndex = 8;
			this.lblBatchSize.Text = "n (batch size)";
			// 
			// lblBatchCount
			// 
			this.lblBatchCount.AutoSize = true;
			this.lblBatchCount.Location = new System.Drawing.Point(8, 164);
			this.lblBatchCount.Margin = new System.Windows.Forms.Padding(5);
			this.lblBatchCount.Name = "lblBatchCount";
			this.lblBatchCount.Size = new System.Drawing.Size(79, 13);
			this.lblBatchCount.TabIndex = 7;
			this.lblBatchCount.Text = "k (batch count)";
			// 
			// tboxBeta
			// 
			this.tboxBeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tboxBeta.DecimalPlaces = 2;
			this.tboxBeta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.tboxBeta.Location = new System.Drawing.Point(90, 49);
			this.tboxBeta.Margin = new System.Windows.Forms.Padding(5);
			this.tboxBeta.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tboxBeta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.tboxBeta.Name = "tboxBeta";
			this.tboxBeta.Size = new System.Drawing.Size(65, 20);
			this.tboxBeta.TabIndex = 4;
			this.tboxBeta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblBeta
			// 
			this.lblBeta.AutoSize = true;
			this.lblBeta.Location = new System.Drawing.Point(8, 51);
			this.lblBeta.Margin = new System.Windows.Forms.Padding(5);
			this.lblBeta.Name = "lblBeta";
			this.lblBeta.Size = new System.Drawing.Size(41, 13);
			this.lblBeta.TabIndex = 3;
			this.lblBeta.Text = "β (m/n)";
			// 
			// tboxAlpha
			// 
			this.tboxAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tboxAlpha.Location = new System.Drawing.Point(90, 19);
			this.tboxAlpha.Margin = new System.Windows.Forms.Padding(5);
			this.tboxAlpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tboxAlpha.Name = "tboxAlpha";
			this.tboxAlpha.Size = new System.Drawing.Size(65, 20);
			this.tboxAlpha.TabIndex = 2;
			this.tboxAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblAlpha
			// 
			this.lblAlpha.AutoSize = true;
			this.lblAlpha.Location = new System.Drawing.Point(8, 21);
			this.lblAlpha.Margin = new System.Windows.Forms.Padding(5);
			this.lblAlpha.Name = "lblAlpha";
			this.lblAlpha.Size = new System.Drawing.Size(14, 13);
			this.lblAlpha.TabIndex = 0;
			this.lblAlpha.Text = "α";
			// 
			// cbHistInteractive
			// 
			this.cbHistInteractive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbHistInteractive.Location = new System.Drawing.Point(2, 107);
			this.cbHistInteractive.Name = "cbHistInteractive";
			this.cbHistInteractive.Size = new System.Drawing.Size(149, 24);
			this.cbHistInteractive.TabIndex = 16;
			this.cbHistInteractive.Text = "Interactive";
			this.cbHistInteractive.UseVisualStyleBackColor = true;
			// 
			// tboxHistSampleSize
			// 
			this.tboxHistSampleSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.tboxHistSampleSize.Location = new System.Drawing.Point(86, 137);
			this.tboxHistSampleSize.Margin = new System.Windows.Forms.Padding(5);
			this.tboxHistSampleSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.tboxHistSampleSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.tboxHistSampleSize.Name = "tboxHistSampleSize";
			this.tboxHistSampleSize.Size = new System.Drawing.Size(65, 20);
			this.tboxHistSampleSize.TabIndex = 16;
			this.tboxHistSampleSize.ThousandsSeparator = true;
			this.tboxHistSampleSize.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 139);
			this.label4.Margin = new System.Windows.Forms.Padding(5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Sample size";
			// 
			// btnCsv
			// 
			this.btnCsv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnCsv.Image")));
			this.btnCsv.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCsv.Name = "btnCsv";
			this.btnCsv.Size = new System.Drawing.Size(64, 22);
			this.btnCsv.Text = "Export csv";
			this.btnCsv.Click += new System.EventHandler(this.OnExportCsv);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 431);
			this.Controls.Add(this.chart);
			this.Controls.Add(this.groupBoxOpts);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.groupBoxOpts.ResumeLayout(false);
			this.groupBoxOpts.PerformLayout();
			this.groupBoxHist.ResumeLayout(false);
			this.groupBoxHist.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tboxHistTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxHistFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxHistCount)).EndInit();
			this.groupBoxGamma.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tboxGammaFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxGammaCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxGammaTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxBatchSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxBatchCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxBeta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxAlpha)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tboxHistSampleSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripLabel lblInfo;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem bruteforceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bootstrapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem method1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnClear;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.ToolStripMenuItem bruteforceToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem method1ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripDropDownButton btnSigma;
		private System.Windows.Forms.ToolStripMenuItem bruteforceToolStripMenuItem2;
		private System.Windows.Forms.GroupBox groupBoxOpts;
		private System.Windows.Forms.Label lblAlpha;
		private System.Windows.Forms.NumericUpDown tboxAlpha;
		private System.Windows.Forms.Label lblBeta;
		private System.Windows.Forms.NumericUpDown tboxBeta;
		private System.Windows.Forms.Label lblGammaFrom;
		private System.Windows.Forms.NumericUpDown tboxGammaFrom;
		private System.Windows.Forms.Label lblBatchSize;
		private System.Windows.Forms.Label lblBatchCount;
		private System.Windows.Forms.NumericUpDown tboxBatchCount;
		private System.Windows.Forms.NumericUpDown tboxBatchSize;
		private System.Windows.Forms.NumericUpDown tboxGammaCount;
		private System.Windows.Forms.NumericUpDown tboxGammaTo;
		private System.Windows.Forms.GroupBox groupBoxGamma;
		private System.Windows.Forms.Label lblGammaTo;
		private System.Windows.Forms.Label lblGammaStep;
		private System.Windows.Forms.GroupBox groupBoxHist;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown tboxHistTo;
		private System.Windows.Forms.NumericUpDown tboxHistFrom;
		private System.Windows.Forms.NumericUpDown tboxHistCount;
		private System.Windows.Forms.CheckBox cbHistInteractive;
		private System.Windows.Forms.NumericUpDown tboxHistSampleSize;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolStripButton btnCsv;

	}
}

