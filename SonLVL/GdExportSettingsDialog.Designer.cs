namespace SonicRetro.SonLVL
{
	partial class GdExportSettingsDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SceneSelector = new SonicRetro.SonLVL.API.FileSelector();
            this.LevelSelector = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProjectRootSelector = new SonicRetro.SonLVL.API.FileSelector();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SceneSelector)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectRootSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // SceneSelector
            // 
            this.SceneSelector.DefaultExt = "tscn";
            this.SceneSelector.FileName = "C:\\path\\to\\file.tscn";
            this.SceneSelector.Filter = "Godot scene files|*.tscn";
            this.SceneSelector.Location = new System.Drawing.Point(6, 19);
            this.SceneSelector.Mode = SonicRetro.SonLVL.API.FileSelectorMode.Save;
            this.SceneSelector.Name = "SceneSelector";
            this.SceneSelector.Size = new System.Drawing.Size(229, 24);
            this.SceneSelector.TabIndex = 3;
            // 
            // LevelSelector
            // 
            this.LevelSelector.FormattingEnabled = true;
            this.LevelSelector.Items.AddRange(new object[] {
            "Levels",
            "go",
            "here"});
            this.LevelSelector.Location = new System.Drawing.Point(6, 49);
            this.LevelSelector.Name = "LevelSelector";
            this.LevelSelector.Size = new System.Drawing.Size(228, 21);
            this.LevelSelector.TabIndex = 6;
            this.LevelSelector.Text = "Levels go here";
            this.LevelSelector.SelectedIndexChanged += new System.EventHandler(this.LevelSelector_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SceneSelector);
            this.groupBox1.Controls.Add(this.LevelSelector);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 81);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Levels and Scenes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProjectRootSelector);
            this.groupBox2.Location = new System.Drawing.Point(13, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 52);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Project Root";
            // 
            // ProjectRootSelector
            // 
            this.ProjectRootSelector.DefaultExt = "godot";
            this.ProjectRootSelector.FileName = "C:\\path\\to\\project.godot";
            this.ProjectRootSelector.Filter = "Godot Projects|project.godot";
            this.ProjectRootSelector.Location = new System.Drawing.Point(7, 20);
            this.ProjectRootSelector.Name = "ProjectRootSelector";
            this.ProjectRootSelector.Size = new System.Drawing.Size(226, 24);
            this.ProjectRootSelector.TabIndex = 0;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(13, 159);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 9;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(95, 159);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 10;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(177, 159);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GdExportSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 191);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GdExportSettingsDialog";
            this.ShowInTaskbar = false;
            this.Text = "Godot Export Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GdExportSettingsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SceneSelector)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProjectRootSelector)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private API.FileSelector SceneSelector;
		private System.Windows.Forms.ComboBox LevelSelector;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private API.FileSelector ProjectRootSelector;
		private System.Windows.Forms.Button ApplyButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CancelButton;
	}
}