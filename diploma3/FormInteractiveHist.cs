using System.Windows.Forms;

namespace diploma3
{
	public partial class FormInteractiveHist : Form
	{
		private int _sampleSize;

		public int SampleSize
		{
			get { return _sampleSize; }
			set
			{
				_sampleSize = value;
				label.Text = "Sample size:" + _sampleSize;
				Refresh();
			}
		}

		public bool Stop { get; set; }

		public FormInteractiveHist()
		{
			InitializeComponent();
			Stop = true;
		}

		private void OnStopClick(object sender, System.EventArgs e) {
			Close();
			Stop = false;
		}
	}
}
