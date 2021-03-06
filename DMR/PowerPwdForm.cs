using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DMR
{
	public class PowerPwdForm : Form
	{
		//private IContainer components;

		private Label lblPwd;

		private SGTextBox txtPwd;

		private Button btnOk;

		private Button btnCancel;

		public PowerPwdForm()
		{
			
			//base._002Ector();
			this.InitializeComponent();
			base.Scale(Class15.smethod_6());
		}

		private void PowerPwdForm_Load(object sender, EventArgs e)
		{
			Class15.smethod_68(this);
			this.txtPwd.MaxByteLength = 16;
			this.txtPwd.InputString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\b";
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			if (this.txtPwd.Text == "DMR961510")
			{
				string string_ = Class7.smethod_0(this.txtPwd.Text.Trim());
				Class6.smethod_6("setup", "Power", string_);
				Class15.smethod_5(Class15.UserMode.Expert);
				Class15.CUR_MODE = 1;
			}
			else if (this.txtPwd.Text == "TYT760")
			{
				string string_2 = Class7.smethod_0(this.txtPwd.Text.Trim());
				Class15.smethod_5(Class15.UserMode.Expert);
				Class15.CUR_MODE = 2;
				Class6.smethod_6("setup", "Power", string_2);
			}
			else
			{
				base.DialogResult = DialogResult.Cancel;
			}
		}

		protected override void Dispose(bool disposing)
		{
            /*
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
             * */
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.lblPwd = new Label();
			this.btnOk = new Button();
			this.btnCancel = new Button();
			this.txtPwd = new SGTextBox();
			base.SuspendLayout();
			this.lblPwd.Location = new Point(31, 47);
			this.lblPwd.Name = "lblPwd";
			this.lblPwd.Size = new Size(69, 23);
			this.lblPwd.TabIndex = 0;
			this.lblPwd.Text = "Password";
			this.lblPwd.TextAlign = ContentAlignment.MiddleRight;
			this.btnOk.DialogResult = DialogResult.OK;
			this.btnOk.Location = new Point(40, 102);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new Size(75, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += this.btnOk_Click;
			this.btnCancel.DialogResult = DialogResult.Cancel;
			this.btnCancel.Location = new Point(154, 102);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.txtPwd.InputString = null;
			this.txtPwd.Location = new Point(108, 47);
			this.txtPwd.MaxByteLength = 0;
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new Size(129, 23);
			this.txtPwd.TabIndex = 1;
			base.AcceptButton = this.btnOk;
			base.AutoScaleDimensions = new SizeF(7f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new Size(268, 153);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.txtPwd);
			base.Controls.Add(this.lblPwd);
			this.Font = new Font("Arial", 10f, FontStyle.Regular);
			base.Name = "PowerPwdForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Password";
			base.Load += this.PowerPwdForm_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
