using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DMR
{
	public class RxGroupListForm : DockContent, IDisp
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct RxListOne
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			private byte[] name;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
			private ushort[] contactList;

			private ushort reserve;

			public string Name
			{
				get
				{
					return Class15.smethod_25(this.name);
				}
				set
				{
					byte[] array = Class15.smethod_23(value);
					this.name.smethod_0((byte)255);
					Array.Copy(array, 0, this.name, 0, Math.Min(array.Length, this.name.Length));
				}
			}

			public ushort[] ContactList
			{
				get
				{
					return this.contactList;
				}
				set
				{
					this.contactList.smethod_0((ushort)0);
					Array.Copy(value, 0, this.contactList, 0, value.Length);
				}
			}

			public byte ValidCount
			{
				get
				{
					List<ushort> list = new List<ushort>(this.contactList);
					List<ushort> list2 = list.FindAll(RxListOne.smethod_0);
					return (byte)list2.Count;
				}
			}

			public RxListOne(int index)
			{
				Class21.mKf3Qywz2M1Yy();
				this = default(RxListOne);
				this.name = new byte[16];
				this.contactList = new ushort[15];
			}

			public void Verify()
			{
				List<ushort> list = new List<ushort>(this.contactList);
				List<ushort> list2 = list.FindAll(RxListOne.smethod_1);
				while (list2.Count < this.contactList.Length)
				{
					list2.Add(0);
				}
				this.contactList = list2.ToArray();
			}

			[CompilerGenerated]
			private static bool smethod_0(ushort ushort_0)
			{
				if (ushort_0 != 0 && ContactForm.data.DataIsValid(ushort_0 - 1))
				{
					return ContactForm.data.IsGroupCall(ushort_0 - 1);
				}
				return false;
			}

			[CompilerGenerated]
			private static bool smethod_1(ushort ushort_0)
			{
				if (ushort_0 != 0 && ContactForm.data.DataIsValid(ushort_0 - 1))
				{
					return ContactForm.data.IsGroupCall(ushort_0 - 1);
				}
				return false;
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public class RxList : IData
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
			private byte[] rxListIndex;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
			private RxListOne[] rxList;

			public RxListOne this[int index]
			{
				get
				{
					if (index >= this.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					return this.rxList[index];
				}
				set
				{
					if (index >= this.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					this.rxList[index] = value;
				}
			}

			public int Count
			{
				get
				{
					return 128;
				}
			}

			public string Format
			{
				get
				{
					return "GroupList{0}";
				}
			}

			public bool ListIsEmpty
			{
				get
				{
					int num = 0;
					while (true)
					{
						if (num < this.Count)
						{
							if (this.DataIsValid(num))
							{
								break;
							}
							num++;
							continue;
						}
						return true;
					}
					return false;
				}
			}

			public RxList()
			{
				Class21.mKf3Qywz2M1Yy();
				//base._002Ector();
				int num = 0;
				this.rxListIndex = new byte[128];
				this.rxList = new RxListOne[128];
				for (num = 0; num < this.Count; num++)
				{
					this.rxList[num] = new RxListOne(num);
				}
			}

			public void Clear()
			{
			}

			public int GetContactCntByIndex(int index)
			{
				if (index < 128)
				{
					if (this.rxListIndex[index] >= 2 && this.rxListIndex[index] <= 16)
					{
						return this.rxListIndex[index] - 1;
					}
					return 0;
				}
				return 0;
			}

			public void SetRxListIndex(int index, bool add)
			{
				if (add)
				{
					this.rxListIndex[index] = 1;
				}
				else
				{
					this.rxListIndex[index] = 0;
				}
			}

			public int GetMinIndex()
			{
				int num = 0;
				num = 0;
				while (true)
				{
					if (num < this.Count)
					{
						if (this.rxListIndex[num] == 0)
						{
							break;
						}
						if (this.rxListIndex[num] > 16)
						{
							break;
						}
						num++;
						continue;
					}
					return -1;
				}
				return num;
			}

			public bool DataIsValid(int index)
			{
				if (this.rxListIndex[index] != 0)
				{
					return this.rxListIndex[index] <= 16;
				}
				return false;
			}

			public void SetIndex(int index, int value)
			{
				this.rxListIndex[index] = (byte)value;
			}

			public void ClearIndex(int index)
			{
				this.rxListIndex[index] = 0;
				ChannelForm.data.ClearByRxGroup(index);
			}

			public void ClearByData(int contactIndex)
			{
				int num = 0;
				int num2 = 0;
				for (num = 0; num < this.Count; num++)
				{
					if (this.DataIsValid(num))
					{
						num2 = Array.IndexOf(this.rxList[num].ContactList, (ushort)(contactIndex + 1));
						if (num2 >= 0)
						{
							this.rxList[num].ContactList.smethod_2(num2);
							this.rxListIndex[num]--;
						}
					}
				}
			}

			public string GetMinName(TreeNode node)
			{
				int num = 0;
				int num2 = 0;
				string text = "";
				num2 = this.GetMinIndex();
				text = string.Format(this.Format, num2 + 1);
				if (!Class15.smethod_51(node, text))
				{
					return text;
				}
				num = 0;
				while (true)
				{
					if (num < this.Count)
					{
						text = string.Format(this.Format, num + 1);
						if (!Class15.smethod_51(node, text))
						{
							break;
						}
						num++;
						continue;
					}
					return "";
				}
				return text;
			}

			public void SetName(int index, string text)
			{
				this.rxList[index].Name = text;
			}

			public string GetName(int index)
			{
				return this.rxList[index].Name;
			}

			public void Default(int index)
			{
				this.rxList[index].ContactList.smethod_0((ushort)0);
			}

			public void Paste(int from, int to)
			{
				this.rxListIndex[to] = this.rxListIndex[from];
				Array.Copy(this.rxList[from].ContactList, this.rxList[to].ContactList, this.rxList[from].ContactList.Length);
			}

			public void Verify()
			{
				int num = 0;
				for (num = 0; num < this.Count; num++)
				{
					if (this.DataIsValid(num))
					{
						this.rxList[num].Verify();
						this.rxListIndex[num] = (byte)(this.rxList[num].ValidCount + 1);
					}
					else
					{
						this.rxListIndex[num] = 0;
					}
				}
			}
		}

		public const int CNT_RX_LIST = 128;

		public const int LEN_RX_LIST_NAME = 16;

		private const int CNT_CONTACT_PER_RX_LIST = 15;

		//private IContainer components;

		private Button btnDel;

		private Button btnAdd;

		private ListBox lstSelected;

		private ListBox lstUnselected;

		private SGTextBox txtName;

		private Label lblName;

		private GroupBox grpUnselected;

		private GroupBox grpSelected;

		private Button btnUp;

		private Button btnDown;

		private Class3 pnlRxGrpList;

		public static RxList data;

		public TreeNode Node
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

		private void method_0()
		{
			this.btnDel = new Button();
			this.btnAdd = new Button();
			this.lstSelected = new ListBox();
			this.lstUnselected = new ListBox();
			this.lblName = new Label();
			this.grpUnselected = new GroupBox();
			this.grpSelected = new GroupBox();
			this.pnlRxGrpList = new Class3();
			this.btnDown = new Button();
			this.btnUp = new Button();
			this.txtName = new SGTextBox();
			this.grpUnselected.SuspendLayout();
			this.grpSelected.SuspendLayout();
			this.pnlRxGrpList.SuspendLayout();
			base.SuspendLayout();
			this.btnDel.Location = new Point(295, 276);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new Size(75, 23);
			this.btnDel.TabIndex = 4;
			this.btnDel.Text = "Delete";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += this.btnDel_Click;
			this.btnAdd.Location = new Point(295, 224);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new Size(75, 23);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += this.btnAdd_Click;
			this.lstSelected.FormattingEnabled = true;
			this.lstSelected.ItemHeight = 16;
			this.lstSelected.Location = new Point(39, 28);
			this.lstSelected.Name = "lstSelected";
			this.lstSelected.SelectionMode = SelectionMode.MultiExtended;
			this.lstSelected.Size = new Size(120, 356);
			this.lstSelected.TabIndex = 5;
			this.lstSelected.SelectedIndexChanged += this.lstSelected_SelectedIndexChanged;
			this.lstSelected.DoubleClick += this.lstSelected_DoubleClick;
			this.lstUnselected.FormattingEnabled = true;
			this.lstUnselected.ItemHeight = 16;
			this.lstUnselected.Location = new Point(44, 28);
			this.lstUnselected.Name = "lstUnselected";
			this.lstUnselected.SelectionMode = SelectionMode.MultiExtended;
			this.lstUnselected.Size = new Size(120, 356);
			this.lstUnselected.TabIndex = 2;
			this.lblName.Location = new Point(226, 50);
			this.lblName.Name = "lblName";
			this.lblName.Size = new Size(64, 23);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name";
			this.lblName.TextAlign = ContentAlignment.MiddleRight;
			this.grpUnselected.Controls.Add(this.lstUnselected);
			this.grpUnselected.Location = new Point(73, 99);
			this.grpUnselected.Name = "grpUnselected";
			this.grpUnselected.Size = new Size(201, 414);
			this.grpUnselected.TabIndex = 6;
			this.grpUnselected.TabStop = false;
			this.grpUnselected.Text = "Available";
			this.grpSelected.Controls.Add(this.lstSelected);
			this.grpSelected.Location = new Point(392, 97);
			this.grpSelected.Name = "grpSelected";
			this.grpSelected.Size = new Size(201, 415);
			this.grpSelected.TabIndex = 7;
			this.grpSelected.TabStop = false;
			this.grpSelected.Text = "Member";
			this.pnlRxGrpList.AutoScroll = true;
			this.pnlRxGrpList.AutoSize = true;
			this.pnlRxGrpList.Controls.Add(this.btnDown);
			this.pnlRxGrpList.Controls.Add(this.btnUp);
			this.pnlRxGrpList.Controls.Add(this.txtName);
			this.pnlRxGrpList.Controls.Add(this.grpSelected);
			this.pnlRxGrpList.Controls.Add(this.btnAdd);
			this.pnlRxGrpList.Controls.Add(this.grpUnselected);
			this.pnlRxGrpList.Controls.Add(this.btnDel);
			this.pnlRxGrpList.Controls.Add(this.lblName);
			this.pnlRxGrpList.Dock = DockStyle.Fill;
			this.pnlRxGrpList.Location = new Point(0, 0);
			this.pnlRxGrpList.Name = "pnlRxGrpList";
			this.pnlRxGrpList.Size = new Size(724, 562);
			this.pnlRxGrpList.TabIndex = 8;
			this.btnDown.Location = new Point(624, 276);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new Size(75, 23);
			this.btnDown.TabIndex = 9;
			this.btnDown.Text = "Down";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += this.btnDown_Click;
			this.btnUp.Location = new Point(624, 224);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new Size(75, 23);
			this.btnUp.TabIndex = 8;
			this.btnUp.Text = "Up";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += this.btnUp_Click;
			this.txtName.InputString = null;
			this.txtName.Location = new Point(299, 50);
			this.txtName.MaxByteLength = 0;
			this.txtName.Name = "txtName";
			this.txtName.Size = new Size(115, 23);
			this.txtName.TabIndex = 1;
			this.txtName.Leave += this.txtName_Leave;
			base.AutoScaleDimensions = new SizeF(7f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(724, 562);
			base.Controls.Add(this.pnlRxGrpList);
			this.Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Name = "RxGroupListForm";
			this.Text = "Rx Group List";
			base.Load += this.RxGroupListForm_Load;
			base.FormClosing += this.RxGroupListForm_FormClosing;
			this.grpUnselected.ResumeLayout(false);
			this.grpSelected.ResumeLayout(false);
			this.pnlRxGrpList.ResumeLayout(false);
			this.pnlRxGrpList.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public void SaveData()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			try
			{
				num3 = Convert.ToInt32(base.Tag);
				if (this.txtName.Focused)
				{
					this.txtName_Leave(this.txtName, null);
				}
				RxListOne value = new RxListOne(num3);
				value.Name = this.txtName.Text;
				num2 = this.lstSelected.Items.Count;
				ushort[] array = new ushort[num2];
				RxGroupListForm.data.SetIndex(num3, num2 + 1);
				foreach (Class14 item in this.lstSelected.Items)
				{
					array[num++] = (ushort)item.Value;
				}
				value.ContactList = array;
				RxGroupListForm.data[num3] = value;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void DispData()
		{
			int num = 0;
			int num2 = 0;
			ushort num3 = 0;
			string text = "";
			int num4 = 0;
			int num5 = 0;
			try
			{
				num2 = Convert.ToInt32(base.Tag);
				this.txtName.Text = RxGroupListForm.data[num2].Name;
				this.lstSelected.Items.Clear();
				num4 = RxGroupListForm.data.GetContactCntByIndex(num2);
				for (num = 0; num < num4; num++)
				{
					num3 = RxGroupListForm.data[num2].ContactList[num];
					if (ContactForm.data.DataIsValid(num3 - 1))
					{
						if (ContactForm.data.IsGroupCall(num3 - 1))
						{
							text = ContactForm.data[num3 - 1].Name;
							this.lstSelected.Items.Add(new Class14(num, num3, text));
						}
						num5++;
					}
				}
				if (num4 != num5 && num5 > 0)
				{
					RxGroupListForm.data.SetIndex(num2, num5 + 1);
				}
				if (this.lstSelected.Items.Count > 0)
				{
					this.lstSelected.SelectedIndex = 0;
				}
				this.lstUnselected.Items.Clear();
				for (num = 0; num < 1024; num++)
				{
					if (!RxGroupListForm.data[num2].ContactList.Contains((ushort)(num + 1)) && ContactForm.data.DataIsValid(num) && ContactForm.data[num].CallType == 0)
					{
						this.lstUnselected.Items.Add(new Class14(-1, num + 1, ContactForm.data[num].Name));
					}
				}
				if (this.lstUnselected.Items.Count > 0)
				{
					this.lstUnselected.SelectedIndex = 0;
				}
				this.method_4();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void RefreshName()
		{
			int index = Convert.ToInt32(base.Tag);
			this.txtName.Text = RxGroupListForm.data[index].Name;
		}

		public RxGroupListForm()
		{
			Class21.mKf3Qywz2M1Yy();
			//base._002Ector();
			this.method_0();
			base.Scale(Class15.smethod_6());
		}

		private void method_1()
		{
			this.txtName.MaxByteLength = 15;
			this.txtName.KeyPress += Class15.smethod_54;
		}

		private void RxGroupListForm_Load(object sender, EventArgs e)
		{
			Class15.smethod_59(base.Controls);
			Class15.smethod_68(this);
			this.method_1();
			this.DispData();
		}

		private void RxGroupListForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.SaveData();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			int num = 0;
			int count = this.lstUnselected.SelectedIndices.Count;
			int num2 = this.lstUnselected.SelectedIndices[count - 1];
			int num3 = 0;
			this.lstSelected.SelectedItems.Clear();
			while (this.lstUnselected.SelectedItems.Count > 0 && this.lstSelected.Items.Count < 15)
			{
				num = this.lstSelected.Items.Count;
				Class14 @class = (Class14)this.lstUnselected.SelectedItems[0];
				@class.method_1(num);
				num3 = this.lstSelected.Items.Add(@class);
				this.lstSelected.SetSelected(num3, true);
				this.lstUnselected.Items.RemoveAt(this.lstUnselected.SelectedIndices[0]);
			}
			if (this.lstUnselected.SelectedItems.Count == 0)
			{
				int num4 = num2 - count + 1;
				if (num4 >= this.lstUnselected.Items.Count)
				{
					num4 = this.lstUnselected.Items.Count - 1;
				}
				this.lstUnselected.SelectedIndex = num4;
			}
			this.method_3();
			this.method_4();
			if (!this.btnAdd.Enabled)
			{
				this.lstSelected.Focus();
			}
		}

		private void btnDel_Click(object sender, EventArgs e)
		{
			int num = 0;
			int count = this.lstSelected.SelectedIndices.Count;
			int num2 = this.lstSelected.SelectedIndices[count - 1];
			this.lstUnselected.SelectedItems.Clear();
			while (this.lstSelected.SelectedItems.Count > 0)
			{
				Class14 @class = (Class14)this.lstSelected.SelectedItems[0];
				num = this.method_2(@class);
				@class.method_1(-1);
				this.lstUnselected.Items.Insert(num, @class);
				this.lstUnselected.SetSelected(num, true);
				this.lstSelected.Items.RemoveAt(this.lstSelected.SelectedIndices[0]);
			}
			int num3 = num2 - count + 1;
			if (num3 >= this.lstSelected.Items.Count)
			{
				num3 = this.lstSelected.Items.Count - 1;
			}
			this.lstSelected.SelectedIndex = num3;
			this.method_3();
			this.method_4();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			int num = 0;
			int num2 = 0;
			int count = this.lstSelected.SelectedIndices.Count;
			int num3 = this.lstSelected.SelectedIndices[count - 1];
			for (num = 0; num < count; num++)
			{
				num2 = this.lstSelected.SelectedIndices[num];
				if (num != num2)
				{
					object value = this.lstSelected.Items[num2];
					this.lstSelected.Items[num2] = this.lstSelected.Items[num2 - 1];
					this.lstSelected.Items[num2 - 1] = value;
					this.lstSelected.SetSelected(num2, false);
					this.lstSelected.SetSelected(num2 - 1, true);
				}
			}
			this.method_3();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int count = this.lstSelected.Items.Count;
			int count2 = this.lstSelected.SelectedIndices.Count;
			int num4 = this.lstSelected.SelectedIndices[count2 - 1];
			num = count2 - 1;
			while (num >= 0)
			{
				num3 = this.lstSelected.SelectedIndices[num];
				if (count - 1 - num2 != num3)
				{
					object value = this.lstSelected.Items[num3];
					this.lstSelected.Items[num3] = this.lstSelected.Items[num3 + 1];
					this.lstSelected.Items[num3 + 1] = value;
					this.lstSelected.SetSelected(num3, false);
					this.lstSelected.SetSelected(num3 + 1, true);
				}
				num--;
				num2++;
			}
			this.method_3();
		}

		private int method_2(Class14 class14_0)
		{
			int num = 0;
			num = 0;
			while (true)
			{
				if (num < this.lstUnselected.Items.Count)
				{
					Class14 @class = (Class14)this.lstUnselected.Items[num];
					if (class14_0.Value < @class.Value)
					{
						break;
					}
					num++;
					continue;
				}
				return num;
			}
			return num;
		}

		private void method_3()
		{
			int num = 0;
			bool flag = false;
			this.lstSelected.BeginUpdate();
			for (num = 0; num < this.lstSelected.Items.Count; num++)
			{
				Class14 @class = (Class14)this.lstSelected.Items[num];
				if (@class.method_0() != num)
				{
					@class.method_1(num);
					flag = this.lstSelected.GetSelected(num);
					this.lstSelected.Items[num] = @class;
					if (flag)
					{
						this.lstSelected.SetSelected(num, true);
					}
				}
			}
			this.lstSelected.EndUpdate();
		}

		private void method_4()
		{
			this.btnAdd.Enabled = (this.lstUnselected.Items.Count > 0 && this.lstSelected.Items.Count < 15);
			this.btnDel.Enabled = (this.lstSelected.Items.Count > 0);
			int count = this.lstSelected.Items.Count;
			int count2 = this.lstSelected.SelectedIndices.Count;
			this.btnUp.Enabled = (this.lstSelected.SelectedItems.Count > 0 && this.lstSelected.Items.Count > 0 && this.lstSelected.SelectedIndices[count2 - 1] != count2 - 1);
			this.btnDown.Enabled = (this.lstSelected.Items.Count > 0 && this.lstSelected.SelectedItems.Count > 0 && this.lstSelected.SelectedIndices[0] != count - count2);
		}

		private void txtName_Leave(object sender, EventArgs e)
		{
			this.txtName.Text = this.txtName.Text.Trim();
			if (this.Node.Text != this.txtName.Text)
			{
				if (Class15.smethod_50(this.Node, this.txtName.Text))
				{
					this.txtName.Text = this.Node.Text;
				}
				else
				{
					this.Node.Text = this.txtName.Text;
				}
			}
		}

		private void lstSelected_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void lstSelected_DoubleClick(object sender, EventArgs e)
		{
			if (this.lstSelected.SelectedItem != null)
			{
				Class14 @class = this.lstSelected.SelectedItem as Class14;
				MainForm mainForm = base.MdiParent as MainForm;
				if (mainForm != null)
				{
					mainForm.DispChildForm(typeof(ContactForm), @class.Value - 1);
				}
			}
		}

		static RxGroupListForm()
		{
			Class21.mKf3Qywz2M1Yy();
			RxGroupListForm.data = new RxList();
		}
	}
}
