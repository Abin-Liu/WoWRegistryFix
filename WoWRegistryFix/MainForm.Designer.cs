namespace WoWRegistryFix
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lblWoWPath = new System.Windows.Forms.Label();
			this.txtWowPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblWoWPath
			// 
			this.lblWoWPath.AutoSize = true;
			this.lblWoWPath.Location = new System.Drawing.Point(12, 9);
			this.lblWoWPath.Name = "lblWoWPath";
			this.lblWoWPath.Size = new System.Drawing.Size(51, 13);
			this.lblWoWPath.TabIndex = 0;
			this.lblWoWPath.Text = "Location:";
			// 
			// txtWowPath
			// 
			this.txtWowPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.txtWowPath.Location = new System.Drawing.Point(15, 34);
			this.txtWowPath.Name = "txtWowPath";
			this.txtWowPath.ReadOnly = true;
			this.txtWowPath.Size = new System.Drawing.Size(351, 20);
			this.txtWowPath.TabIndex = 1;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Image = global::WoWRegistryFix.Properties.Resources.folder;
			this.btnBrowse.Location = new System.Drawing.Point(372, 32);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(35, 23);
			this.btnBrowse.TabIndex = 2;
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(122, 74);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(225, 74);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Exit";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 115);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtWowPath);
			this.Controls.Add(this.lblWoWPath);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WoW Registry Fix";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblWoWPath;
		private System.Windows.Forms.TextBox txtWowPath;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}

