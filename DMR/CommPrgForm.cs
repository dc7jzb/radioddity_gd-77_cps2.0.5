using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DMR
{
	public class CommPrgForm : Form
	{
		//private IContainer components;
		private Label lblPrompt;
		private ProgressBar prgComm;
		private Button btnCancel;
		private Class9 firmwareUpdate;
		private Class10 portComm;
		private Class19 hidComm;

		public bool IsRead
		{
			get;
			set;
		}

		public bool IsSucess
		{
			get;
			set;
		}

		protected override void Dispose(bool disposing)
		{
            /*
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}*/
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.lblPrompt = new Label();
			this.prgComm = new ProgressBar();
			this.btnCancel = new Button();
			base.SuspendLayout();
			this.lblPrompt.BorderStyle = BorderStyle.Fixed3D;
			this.lblPrompt.Location = new Point(43, 118);
			this.lblPrompt.Name = "lblPrompt";
			this.lblPrompt.Size = new Size(380, 26);
			this.lblPrompt.TabIndex = 0;
			this.prgComm.Location = new Point(43, 70);
			this.prgComm.Margin = new Padding(3, 4, 3, 4);
			this.prgComm.Name = "prgComm";
			this.prgComm.Size = new Size(380, 31);
			this.prgComm.TabIndex = 1;
			this.btnCancel.Location = new Point(184, 161);
			this.btnCancel.Margin = new Padding(3, 4, 3, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(87, 31);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += this.btnCancel_Click;
			base.AutoScaleDimensions = new SizeF(7f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(468, 214);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.prgComm);
			base.Controls.Add(this.lblPrompt);
			this.Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Margin = new Padding(3, 4, 3, 4);
			base.Name = "CommPrgForm";
			base.ShowInTaskbar = false;
			base.Load += this.CommPrgForm_Load;
			base.FormClosing += this.CommPrgForm_FormClosing;
			base.ResumeLayout(false);
		}

		public CommPrgForm()
		{
			//Class21.mKf3Qywz2M1Yy();
			this.firmwareUpdate = new Class9();
			this.portComm = new Class10();
			this.hidComm = new Class19();
			//base._002Ector();
			this.InitializeComponent();
			base.Scale(Class15.smethod_6());
		}

		private void CommPrgForm_Load(object sender, EventArgs e)
		{
			Class15.smethod_68(this);
			this.prgComm.Minimum = 0;
			this.prgComm.Maximum = 100;
			this.firmwareUpdate.method_3(this.IsRead);
			if (this.IsRead)
			{
				this.Text = Class15.dicCommon["Read"];
			}
			else
			{
				this.Text = Class15.dicCommon["Write"];
			}
			this.hidComm.method_3(this.IsRead);
			if (this.IsRead)
			{
				this.hidComm.START_ADDR = new int[7]
				{
					128,
					304,
					21392,
					29976,
					32768,
					44816,
					95776
				};
				this.hidComm.END_ADDR = new int[7]
				{
					297,
					14208,
					22056,
					30208,
					32784,
					45488,
					126624
				};
			}
			else
			{
				this.hidComm.START_ADDR = new int[7]
				{
					128,
					304,
					21392,
					29976,
					32768,
					44816,
					95776
				};
				this.hidComm.END_ADDR = new int[7]
				{
					297,
					14208,
					22056,
					30208,
					32784,
					45488,
					126624
				};
			}
			this.hidComm.method_9(this.method_0);
			this.hidComm.method_6();
		}

		private void CommPrgForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.hidComm.method_4())
			{
				this.hidComm.method_1(true);
				this.hidComm.method_5();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void method_0(object sender, FirmwareUpdateProgressEventArgs e)
		{
			if (this.prgComm.InvokeRequired)
			{
				base.BeginInvoke(new EventHandler<FirmwareUpdateProgressEventArgs>(this.method_0), sender, e);
			}
			else if (e.Failed)
			{
				if (!string.IsNullOrEmpty(e.Message))
				{
					MessageBox.Show(e.Message, Class15.SZ_PROMPT);
				}
				base.Close();
			}
			else if (e.Closed)
			{
				this.Refresh();
				base.Close();
			}
			else
			{
				this.prgComm.Value = (int)e.Percentage;
				this.lblPrompt.Text = string.Format("{0}%", this.prgComm.Value);
				if (e.Percentage == (float)this.prgComm.Maximum)
				{
					this.IsSucess = true;
					if (this.IsRead)
					{
						MessageBox.Show(Class15.dicCommon["ReadComplete"]);
					}
					else
					{
						MessageBox.Show(Class15.dicCommon["WriteComplete"]);
					}
				}
			}
		}
	}
}
