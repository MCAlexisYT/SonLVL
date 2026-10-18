using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SonicRetro.SonLVL.GodotExporter;

namespace SonicRetro.SonLVL
{
	public partial class GdExportSettingsDialog : Form
	{

		private Dictionary<string, string> LevelPaths = new Dictionary<string, string>();

		public GdExportSettingsDialog()
		{
			InitializeComponent();
		}

		private void GdExportSettingsDialog_Load(object sender, EventArgs e)
		{
			LevelPaths = new Dictionary<string, string>(GodotExporter.Exporter.LevelPaths);
			LevelSelector.Items.Clear();
			LevelSelector.Items.AddRange(LevelPaths.Keys.ToArray());
			LevelSelector.SelectedIndex = 0;
			
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ApplyButton_Click(object sender, EventArgs e)
		{

		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			ApplyButton_Click(sender, e);
			CancelButton_Click(sender, e);
		}

		private void LevelSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
	}
}
