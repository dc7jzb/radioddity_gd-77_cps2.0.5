using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DMR
{
	public class AboutForm : Form
	{
		//private IContainer components;

		private Label lblVersion;

		private Label lblCompany;

		private Button btnClose;

		public AboutForm()
		{
			
			//base._002Ector();
			this.InitializeComponent();
			base.Scale(Class15.smethod_6());
		}

		private void AboutForm_Load(object sender, EventArgs e)
		{
			Class15.smethod_68(this);
			this.lblVersion.Text = Class6.smethod_4("Info", "Version", "v1.0.0");
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
		/*	if (disposing && this.components != null)
			{
				this.components.Dispose();
			}*/
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.lblVersion = new Label();
			this.lblCompany = new Label();
			this.btnClose = new Button();
			base.SuspendLayout();
			this.lblVersion.Location = new Point(31, 68);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new Size(351, 20);
			this.lblVersion.TabIndex = 0;
			this.lblVersion.Text = "v1.0.0";
			this.lblVersion.TextAlign = ContentAlignment.MiddleCenter;
			this.lblCompany.Location = new Point(31, 117);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new Size(351, 20);
			this.lblCompany.TabIndex = 0;
			this.lblCompany.Text = "Company";
			this.lblCompany.TextAlign = ContentAlignment.MiddleCenter;
			this.btnClose.Location = new Point(173, 191);
			this.btnClose.Margin = new Padding(3, 4, 3, 4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new Size(64, 27);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "OK";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += this.btnClose_Click;
			base.AutoScaleDimensions = new SizeF(7f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(409, 299);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.lblCompany);
			base.Controls.Add(this.lblVersion);
			this.Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Margin = new Padding(3, 4, 3, 4);
			base.Name = "AboutForm";
			this.Text = "About";
			base.Load += this.AboutForm_Load;
			base.ResumeLayout(false);
		}
	}
}
