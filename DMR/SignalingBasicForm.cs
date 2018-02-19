using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DMR
{
	public class SignalingBasicForm : DockContent, IDisp
	{
		[Serializable]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public class SignalingBasic : IVerify<SignalingBasic>
		{
			private byte rmDuration;

			private byte txSyncWakeTot;

			private byte selCallHang;

			private byte autoResetTimer;

			private byte flag1;

			private byte flag2;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			private byte[] reserve;

			public decimal RmDuration
			{
				get
				{
					if (this.rmDuration >= 1 && this.rmDuration <= 12)
					{
						return this.rmDuration * 10;
					}
					return 10m;
				}
				set
				{
					byte b = Convert.ToByte(value / 10m);
					if (b >= 1 && b <= 12)
					{
						this.rmDuration = b;
					}
					else
					{
						this.rmDuration = 1;
					}
				}
			}

			public decimal TxSyncWakeTot
			{
				get
				{
					if (this.txSyncWakeTot >= 5 && this.txSyncWakeTot <= 15)
					{
						return this.txSyncWakeTot * 25;
					}
					return 250m;
				}
				set
				{
					byte b = Convert.ToByte(value / 25m);
					if (b >= 5 && b <= 15)
					{
						this.txSyncWakeTot = b;
					}
					else
					{
						this.txSyncWakeTot = 10;
					}
				}
			}

			public int SelCallHang
			{
				get
				{
					if (this.selCallHang >= 0 && this.selCallHang <= 14)
					{
						return this.selCallHang * 500;
					}
					return 4000;
				}
				set
				{
					value /= 500;
					if (value >= 0 && value <= 14)
					{
						this.selCallHang = Convert.ToByte(value);
					}
					else
					{
						this.selCallHang = 8;
					}
				}
			}

			public byte AutoResetTimer
			{
				get
				{
					if (this.autoResetTimer >= 1 && this.autoResetTimer <= 255)
					{
						return this.autoResetTimer;
					}
					return 10;
				}
				set
				{
					if (value >= 1 && value <= 255)
					{
						this.autoResetTimer = value;
					}
					else
					{
						this.autoResetTimer = 10;
					}
				}
			}

			public bool RadioDisable
			{
				get
				{
					return Convert.ToBoolean(this.flag1 & 0x80);
				}
				set
				{
					if (value)
					{
						this.flag1 |= 128;
					}
					else
					{
						this.flag1 &= 127;
					}
				}
			}

			public bool RemoteMonitor
			{
				get
				{
					return Convert.ToBoolean(this.flag1 & 0x40);
				}
				set
				{
					if (value)
					{
						this.flag1 |= 64;
					}
					else
					{
						this.flag1 &= 191;
					}
				}
			}

			public bool EmgRm
			{
				get
				{
					return Convert.ToBoolean(this.flag1 & 0x20);
				}
				set
				{
					if (value)
					{
						this.flag1 |= 32;
					}
					else
					{
						this.flag1 &= 223;
					}
				}
			}

			public decimal TxWakeMsgLimit
			{
				get
				{
					byte b = Convert.ToByte((this.flag1 & 0x1C) >> 2);
					if (b >= 0 && b <= 4)
					{
						return b;
					}
					return 2m;
				}
				set
				{
					if (!(value >= 0m) || !(value <= 4m))
					{
						value = 2m;
					}
					value = ((int)value << 2 & 0x1C);
					this.flag1 &= 227;
					this.flag1 |= (byte)value;
				}
			}

			public bool CallAlert
			{
				get
				{
					return Convert.ToBoolean(this.flag2 & 0x80);
				}
				set
				{
					if (value)
					{
						this.flag2 |= 128;
					}
					else
					{
						this.flag2 &= 127;
					}
				}
			}

			public bool SelCallCode
			{
				get
				{
					return Convert.ToBoolean(this.flag2 & 0x40);
				}
				set
				{
					if (value)
					{
						this.flag2 |= 64;
					}
					else
					{
						this.flag2 &= 191;
					}
				}
			}

			public int SelCallToneId
			{
				get
				{
					return (this.flag2 & 0x20) >> 5;
				}
				set
				{
					this.flag2 &= 223;
					this.flag2 |= Convert.ToByte(value << 5 & 0x20);
				}
			}

			public void Verify(SignalingBasic def)
			{
				Class15.smethod_11(ref this.rmDuration, (byte)1, (byte)12, def.rmDuration);
				Class15.smethod_11(ref this.txSyncWakeTot, (byte)5, (byte)15, def.txSyncWakeTot);
				Class15.smethod_11(ref this.selCallHang, (byte)0, (byte)14, def.selCallHang);
				Class15.smethod_11(ref this.autoResetTimer, (byte)1, (byte)255, def.autoResetTimer);
				byte b = Convert.ToByte((this.flag1 & 0x1C) >> 2);
				if (b >= 0 && b <= 4)
				{
					return;
				}
				this.flag1 &= 227;
				this.flag1 |= (byte)(def.flag1 & 0x1C);
			}

			public SignalingBasic()
			{
				
				//base._002Ector();
			}
		}

		private const byte MIN_RM_DURATION = 1;

		private const byte MAX_RM_DURATION = 12;

		private const byte SCL_RM_DURATION = 10;

		private const byte INC_RM_DURATION = 1;

		private const byte LEN_RM_DURATION = 3;

		private const string SZ_RM_DURATION = "0123456789";

		private const byte MIN_TX_SYNC_WAKE_TOT = 5;

		private const byte MAX_TX_SYNC_WAKE_TOT = 15;

		private const byte INC_TX_SYNC_WAKE_TOT = 1;

		private const byte SCL_TX_SYNC_WAKE_TOT = 25;

		private const byte LEN_TX_SYNC_WAKE_TOT = 3;

		private const string SZ_TX_SYNC_WAKE_TOT = "0123456789";

		private const byte MIN_SEL_CALL_HANG = 0;

		private const byte MAX_SEL_CALL_HANG = 14;

		private const ushort SCL_SEL_CALL_HANG = 500;

		private const byte INC_SEL_CALL_HANG = 1;

		private const byte LEN_SEL_CALL_HANG = 4;

		private const byte MIN_AUTO_RESET_TIMER = 1;

		private const byte MAX_AUTO_RESET_TIMER = 255;

		private const byte INC_AUTO_RESET_TIMER = 1;

		private const byte SCL_AUTO_RESET_TIMER = 1;

		private const byte LEN_AUTO_RESET_TIMER = 3;

		private const byte MIN_TX_WAKE_MSG_LIMIT = 0;

		private const byte MAX_TX_WAKE_MSG_LIMIT = 4;

		private const byte INC_TX_WAKE_MSG_LIMIT = 1;

		private const byte SCL_TX_WAKE_MSG_LIMIT = 1;

		private const byte LEN_TX_WAKE_MSG_LIMIT = 1;

		public static SignalingBasic DefaultSignalingBasic;

		public static SignalingBasic data;

		//private IContainer components;

		private CheckBox chkCallAlert;

		private CheckBox chkSelCall;

		private ComboBox cmbSelCallToneId;

		private Label lblSelCallToneId;

		private Label lblSelCallHang;

		private Label lblAutoResetTimer;

		private CheckBox chkRadioDisable;

		private CheckBox chkRemoteMonitor;

		private CheckBox chkEmgRM;

		private Label lblRMDuration;

		private Label lblTxSyncWakeTot;

		private Label lblTxWakeMsgLimit;

		private Class12 nudSelCallHang;

		private Class12 nudAutoResetTimer;

		private Class12 nudRMDuration;

		private Class12 nudTxSyncWakeTot;

		private Class12 nudTxWakeMsgLimit;

		private Class3 pnlSignalingBasic;

		public TreeNode Node
		{
			get;
			set;
		}

		public void SaveData()
		{
			try
			{
				SignalingBasicForm.data.RmDuration = this.nudRMDuration.Value;
				SignalingBasicForm.data.TxSyncWakeTot = this.nudTxSyncWakeTot.Value;
				SignalingBasicForm.data.RadioDisable = this.chkRadioDisable.Checked;
				SignalingBasicForm.data.RemoteMonitor = this.chkRemoteMonitor.Checked;
				SignalingBasicForm.data.EmgRm = this.chkEmgRM.Checked;
				SignalingBasicForm.data.TxWakeMsgLimit = this.nudTxWakeMsgLimit.Value;
				SignalingBasicForm.data.CallAlert = this.chkCallAlert.Checked;
				SignalingBasicForm.data.SelCallCode = this.chkSelCall.Checked;
				SignalingBasicForm.data.SelCallToneId = this.cmbSelCallToneId.SelectedIndex;
				SignalingBasicForm.data.SelCallHang = (int)this.nudSelCallHang.Value;
				SignalingBasicForm.data.AutoResetTimer = (byte)this.nudAutoResetTimer.Value;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void DispData()
		{
			try
			{
				this.method_0();
				this.chkRadioDisable.Checked = SignalingBasicForm.data.RadioDisable;
				this.chkRemoteMonitor.Checked = SignalingBasicForm.data.RemoteMonitor;
				this.chkEmgRM.Checked = SignalingBasicForm.data.EmgRm;
				this.nudRMDuration.Value = SignalingBasicForm.data.RmDuration;
				this.nudTxWakeMsgLimit.Value = SignalingBasicForm.data.TxWakeMsgLimit;
				this.nudTxSyncWakeTot.Value = SignalingBasicForm.data.TxSyncWakeTot;
				this.chkCallAlert.Checked = SignalingBasicForm.data.CallAlert;
				this.chkSelCall.Checked = SignalingBasicForm.data.SelCallCode;
				this.cmbSelCallToneId.SelectedIndex = SignalingBasicForm.data.SelCallToneId;
				this.nudSelCallHang.Value = SignalingBasicForm.data.SelCallHang;
				this.nudAutoResetTimer.Value = SignalingBasicForm.data.AutoResetTimer;
				this.RefreshByUserMode();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void RefreshByUserMode()
		{
			bool flag = Class15.smethod_4() == Class15.UserMode.Expert;
			this.chkRadioDisable.Enabled &= flag;
			this.chkRemoteMonitor.Enabled &= flag;
			this.chkEmgRM.Enabled &= flag;
			this.lblTxWakeMsgLimit.Enabled &= flag;
			this.nudTxWakeMsgLimit.Enabled &= flag;
			this.lblRMDuration.Enabled &= flag;
			this.nudRMDuration.Enabled &= flag;
			this.lblTxSyncWakeTot.Enabled &= flag;
			this.nudTxSyncWakeTot.Enabled &= flag;
		}

		public void RefreshName()
		{
		}

		public SignalingBasicForm()
		{
			
			//base._002Ector();
			this.method_1();
			base.Scale(Class15.smethod_6());
		}

		private void method_0()
		{
			this.nudRMDuration.Minimum = 10m;
			this.nudRMDuration.Maximum = 120m;
			this.nudRMDuration.Increment = 10m;
			this.nudRMDuration.method_0(3);
			this.nudTxSyncWakeTot.Minimum = 125m;
			this.nudTxSyncWakeTot.Maximum = 375m;
			this.nudTxSyncWakeTot.Increment = 25m;
			this.nudTxSyncWakeTot.method_0(3);
			Class15.smethod_36(this.nudTxWakeMsgLimit, new Class13(0, 4, 1, 1m, 1));
			Class15.smethod_36(this.nudSelCallHang, new Class13(0, 14, 1, 500m, 4));
			Class15.smethod_36(this.nudAutoResetTimer, new Class13(1, 255, 1, 1m, 3));
		}

		private void SignalingBasicForm_Load(object sender, EventArgs e)
		{
			Class15.smethod_59(base.Controls);
			Class15.smethod_68(this);
			this.DispData();
		}

		private void SignalingBasicForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.SaveData();
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

		private void method_1()
		{
			this.pnlSignalingBasic = new Class3();
			this.nudTxSyncWakeTot = new Class12();
			this.chkCallAlert = new CheckBox();
			this.nudAutoResetTimer = new Class12();
			this.chkRadioDisable = new CheckBox();
			this.nudTxWakeMsgLimit = new Class12();
			this.chkRemoteMonitor = new CheckBox();
			this.nudRMDuration = new Class12();
			this.chkEmgRM = new CheckBox();
			this.lblTxSyncWakeTot = new Label();
			this.chkSelCall = new CheckBox();
			this.lblTxWakeMsgLimit = new Label();
			this.cmbSelCallToneId = new ComboBox();
			this.nudSelCallHang = new Class12();
			this.lblSelCallToneId = new Label();
			this.lblRMDuration = new Label();
			this.lblSelCallHang = new Label();
			this.lblAutoResetTimer = new Label();
			this.pnlSignalingBasic.SuspendLayout();
			((ISupportInitialize)this.nudTxSyncWakeTot).BeginInit();
			((ISupportInitialize)this.nudAutoResetTimer).BeginInit();
			((ISupportInitialize)this.nudTxWakeMsgLimit).BeginInit();
			((ISupportInitialize)this.nudRMDuration).BeginInit();
			((ISupportInitialize)this.nudSelCallHang).BeginInit();
			base.SuspendLayout();
			this.pnlSignalingBasic.AutoScroll = true;
			this.pnlSignalingBasic.AutoSize = true;
			this.pnlSignalingBasic.Controls.Add(this.nudTxSyncWakeTot);
			this.pnlSignalingBasic.Controls.Add(this.chkCallAlert);
			this.pnlSignalingBasic.Controls.Add(this.nudAutoResetTimer);
			this.pnlSignalingBasic.Controls.Add(this.chkRadioDisable);
			this.pnlSignalingBasic.Controls.Add(this.nudTxWakeMsgLimit);
			this.pnlSignalingBasic.Controls.Add(this.chkRemoteMonitor);
			this.pnlSignalingBasic.Controls.Add(this.nudRMDuration);
			this.pnlSignalingBasic.Controls.Add(this.chkEmgRM);
			this.pnlSignalingBasic.Controls.Add(this.lblTxSyncWakeTot);
			this.pnlSignalingBasic.Controls.Add(this.chkSelCall);
			this.pnlSignalingBasic.Controls.Add(this.lblTxWakeMsgLimit);
			this.pnlSignalingBasic.Controls.Add(this.cmbSelCallToneId);
			this.pnlSignalingBasic.Controls.Add(this.nudSelCallHang);
			this.pnlSignalingBasic.Controls.Add(this.lblSelCallToneId);
			this.pnlSignalingBasic.Controls.Add(this.lblRMDuration);
			this.pnlSignalingBasic.Controls.Add(this.lblSelCallHang);
			this.pnlSignalingBasic.Controls.Add(this.lblAutoResetTimer);
			this.pnlSignalingBasic.Dock = DockStyle.Fill;
			this.pnlSignalingBasic.Location = new Point(0, 0);
			this.pnlSignalingBasic.Name = "pnlSignalingBasic";
			this.pnlSignalingBasic.Size = new Size(521, 397);
			this.pnlSignalingBasic.TabIndex = 0;
			this.nudTxSyncWakeTot.Increment = new decimal(new int[4]
			{
				5,
				0,
				0,
				0
			});
			this.nudTxSyncWakeTot.method_2(null);
			this.nudTxSyncWakeTot.Location = new Point(245, 158);
			this.nudTxSyncWakeTot.Maximum = new decimal(new int[4]
			{
				375,
				0,
				0,
				0
			});
			this.nudTxSyncWakeTot.Minimum = new decimal(new int[4]
			{
				125,
				0,
				0,
				0
			});
			this.nudTxSyncWakeTot.Name = "nudTxSyncWakeTot";
			this.nudTxSyncWakeTot.method_6(null);
			Class12 @class = this.nudTxSyncWakeTot;
			int[] bits = new int[4];
			@class.method_4(new decimal(bits));
			this.nudTxSyncWakeTot.Size = new Size(120, 23);
			this.nudTxSyncWakeTot.TabIndex = 8;
			this.nudTxSyncWakeTot.Value = new decimal(new int[4]
			{
				125,
				0,
				0,
				0
			});
			this.chkCallAlert.AutoSize = true;
			this.chkCallAlert.Location = new Point(245, 188);
			this.chkCallAlert.Name = "chkCallAlert";
			this.chkCallAlert.Size = new Size(135, 20);
			this.chkCallAlert.TabIndex = 9;
			this.chkCallAlert.Text = "Call Alert Encode";
			this.chkCallAlert.UseVisualStyleBackColor = true;
			this.chkCallAlert.Visible = false;
			this.nudAutoResetTimer.method_2(null);
			this.nudAutoResetTimer.Location = new Point(245, 308);
			this.nudAutoResetTimer.Maximum = new decimal(new int[4]
			{
				255,
				0,
				0,
				0
			});
			this.nudAutoResetTimer.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			this.nudAutoResetTimer.Name = "nudAutoResetTimer";
			this.nudAutoResetTimer.method_6(null);
			Class12 class2 = this.nudAutoResetTimer;
			int[] bits2 = new int[4];
			class2.method_4(new decimal(bits2));
			this.nudAutoResetTimer.Size = new Size(120, 23);
			this.nudAutoResetTimer.TabIndex = 16;
			this.nudAutoResetTimer.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			this.nudAutoResetTimer.Visible = false;
			this.chkRadioDisable.AutoSize = true;
			this.chkRadioDisable.Location = new Point(245, 18);
			this.chkRadioDisable.Name = "chkRadioDisable";
			this.chkRadioDisable.Size = new Size(168, 20);
			this.chkRadioDisable.TabIndex = 0;
			this.chkRadioDisable.Text = "Radio Disable Decode";
			this.chkRadioDisable.UseVisualStyleBackColor = true;
			this.nudTxWakeMsgLimit.method_2(null);
			this.nudTxWakeMsgLimit.Location = new Point(245, 98);
			this.nudTxWakeMsgLimit.Maximum = new decimal(new int[4]
			{
				4,
				0,
				0,
				0
			});
			this.nudTxWakeMsgLimit.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			this.nudTxWakeMsgLimit.Name = "nudTxWakeMsgLimit";
			this.nudTxWakeMsgLimit.method_6(null);
			Class12 class3 = this.nudTxWakeMsgLimit;
			int[] bits3 = new int[4];
			class3.method_4(new decimal(bits3));
			this.nudTxWakeMsgLimit.Size = new Size(120, 23);
			this.nudTxWakeMsgLimit.TabIndex = 4;
			this.nudTxWakeMsgLimit.Value = new decimal(new int[4]
			{
				4,
				0,
				0,
				0
			});
			this.chkRemoteMonitor.AutoSize = true;
			this.chkRemoteMonitor.Location = new Point(245, 42);
			this.chkRemoteMonitor.Name = "chkRemoteMonitor";
			this.chkRemoteMonitor.Size = new Size(180, 20);
			this.chkRemoteMonitor.TabIndex = 1;
			this.chkRemoteMonitor.Text = "Remote Monitor Decode";
			this.chkRemoteMonitor.UseVisualStyleBackColor = true;
			this.nudRMDuration.Increment = new decimal(new int[4]
			{
				10,
				0,
				0,
				0
			});
			this.nudRMDuration.method_2(null);
			this.nudRMDuration.Location = new Point(245, 128);
			this.nudRMDuration.Maximum = new decimal(new int[4]
			{
				120,
				0,
				0,
				0
			});
			this.nudRMDuration.Minimum = new decimal(new int[4]
			{
				10,
				0,
				0,
				0
			});
			this.nudRMDuration.Name = "nudRMDuration";
			this.nudRMDuration.method_6(null);
			Class12 class4 = this.nudRMDuration;
			int[] bits4 = new int[4];
			class4.method_4(new decimal(bits4));
			this.nudRMDuration.Size = new Size(120, 23);
			this.nudRMDuration.TabIndex = 6;
			this.nudRMDuration.Value = new decimal(new int[4]
			{
				10,
				0,
				0,
				0
			});
			this.chkEmgRM.AutoSize = true;
			this.chkEmgRM.Location = new Point(245, 68);
			this.chkEmgRM.Name = "chkEmgRM";
			this.chkEmgRM.Size = new Size(255, 20);
			this.chkEmgRM.TabIndex = 2;
			this.chkEmgRM.Text = "Emergency Romote Monitor Decode";
			this.chkEmgRM.UseVisualStyleBackColor = true;
			this.lblTxSyncWakeTot.Location = new Point(49, 158);
			this.lblTxSyncWakeTot.Name = "lblTxSyncWakeTot";
			this.lblTxSyncWakeTot.Size = new Size(185, 24);
			this.lblTxSyncWakeTot.TabIndex = 7;
			this.lblTxSyncWakeTot.Text = "Tx Sync Wakeup TOT [ms]";
			this.lblTxSyncWakeTot.TextAlign = ContentAlignment.MiddleRight;
			this.chkSelCall.AutoSize = true;
			this.chkSelCall.Location = new Point(245, 218);
			this.chkSelCall.Name = "chkSelCall";
			this.chkSelCall.Size = new Size(131, 20);
			this.chkSelCall.TabIndex = 10;
			this.chkSelCall.Text = "Self Call Encode";
			this.chkSelCall.UseVisualStyleBackColor = true;
			this.chkSelCall.Visible = false;
			this.lblTxWakeMsgLimit.Location = new Point(49, 98);
			this.lblTxWakeMsgLimit.Name = "lblTxWakeMsgLimit";
			this.lblTxWakeMsgLimit.Size = new Size(185, 24);
			this.lblTxWakeMsgLimit.TabIndex = 3;
			this.lblTxWakeMsgLimit.Text = "Tx Wakeup Message Limit";
			this.lblTxWakeMsgLimit.TextAlign = ContentAlignment.MiddleRight;
			this.cmbSelCallToneId.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSelCallToneId.FormattingEnabled = true;
			this.cmbSelCallToneId.Items.AddRange(new object[2]
			{
				"前置",
				"始终"
			});
			this.cmbSelCallToneId.Location = new Point(245, 248);
			this.cmbSelCallToneId.Name = "cmbSelCallToneId";
			this.cmbSelCallToneId.Size = new Size(121, 24);
			this.cmbSelCallToneId.TabIndex = 12;
			this.cmbSelCallToneId.Visible = false;
			this.nudSelCallHang.Increment = new decimal(new int[4]
			{
				500,
				0,
				0,
				0
			});
			this.nudSelCallHang.method_2(null);
			this.nudSelCallHang.Location = new Point(245, 278);
			this.nudSelCallHang.Maximum = new decimal(new int[4]
			{
				7000,
				0,
				0,
				0
			});
			this.nudSelCallHang.Name = "nudSelCallHang";
			this.nudSelCallHang.method_6(null);
			Class12 class5 = this.nudSelCallHang;
			int[] bits5 = new int[4];
			class5.method_4(new decimal(bits5));
			this.nudSelCallHang.Size = new Size(120, 23);
			this.nudSelCallHang.TabIndex = 14;
			this.nudSelCallHang.Visible = false;
			this.lblSelCallToneId.Location = new Point(49, 248);
			this.lblSelCallToneId.Name = "lblSelCallToneId";
			this.lblSelCallToneId.Size = new Size(185, 24);
			this.lblSelCallToneId.TabIndex = 11;
			this.lblSelCallToneId.Text = "Self Call Tone/ID";
			this.lblSelCallToneId.TextAlign = ContentAlignment.MiddleRight;
			this.lblSelCallToneId.Visible = false;
			this.lblRMDuration.Location = new Point(49, 128);
			this.lblRMDuration.Name = "lblRMDuration";
			this.lblRMDuration.Size = new Size(185, 24);
			this.lblRMDuration.TabIndex = 5;
			this.lblRMDuration.Text = "Remote Monitor Duration [s]";
			this.lblRMDuration.TextAlign = ContentAlignment.MiddleRight;
			this.lblSelCallHang.Location = new Point(49, 278);
			this.lblSelCallHang.Name = "lblSelCallHang";
			this.lblSelCallHang.Size = new Size(185, 24);
			this.lblSelCallHang.TabIndex = 13;
			this.lblSelCallHang.Text = "Self Call Hang Time [ms]";
			this.lblSelCallHang.TextAlign = ContentAlignment.MiddleRight;
			this.lblSelCallHang.Visible = false;
			this.lblAutoResetTimer.Location = new Point(49, 308);
			this.lblAutoResetTimer.Name = "lblAutoResetTimer";
			this.lblAutoResetTimer.Size = new Size(185, 24);
			this.lblAutoResetTimer.TabIndex = 15;
			this.lblAutoResetTimer.Text = "Auto Reset Timer [s]";
			this.lblAutoResetTimer.TextAlign = ContentAlignment.MiddleRight;
			this.lblAutoResetTimer.Visible = false;
			base.AutoScaleDimensions = new SizeF(7f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(521, 397);
			base.Controls.Add(this.pnlSignalingBasic);
			this.Font = new Font("Arial", 10f, FontStyle.Regular);
			base.Name = "SignalingBasicForm";
			this.Text = "Signaling System";
			base.Load += this.SignalingBasicForm_Load;
			base.FormClosing += this.SignalingBasicForm_FormClosing;
			this.pnlSignalingBasic.ResumeLayout(false);
			this.pnlSignalingBasic.PerformLayout();
			((ISupportInitialize)this.nudTxSyncWakeTot).EndInit();
			((ISupportInitialize)this.nudAutoResetTimer).EndInit();
			((ISupportInitialize)this.nudTxWakeMsgLimit).EndInit();
			((ISupportInitialize)this.nudRMDuration).EndInit();
			((ISupportInitialize)this.nudSelCallHang).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		static SignalingBasicForm()
		{
			
			SignalingBasicForm.DefaultSignalingBasic = new SignalingBasic();
			SignalingBasicForm.data = new SignalingBasic();
		}
	}
}
