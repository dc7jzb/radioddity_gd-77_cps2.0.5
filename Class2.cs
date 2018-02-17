using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class Class2 : GroupBox
{
    bool _003CDoubleClickSelectCheckBox_003Ek__BackingField;
	[CompilerGenerated]
	public bool method_0()
	{
		return this._003CDoubleClickSelectCheckBox_003Ek__BackingField;
	}

	[CompilerGenerated]
	public void method_1(bool bool_0)
	{
		this._003CDoubleClickSelectCheckBox_003Ek__BackingField = bool_0;
	}

    bool _003CClickFocus_003Ek__BackingField;
	[CompilerGenerated]
	public bool method_2()
	{
		return this._003CClickFocus_003Ek__BackingField;
	}

	[CompilerGenerated]
	public void method_3(bool bool_0)
	{
		this._003CClickFocus_003Ek__BackingField = bool_0;
	}

	public Class2()
	{
		
		//base._002Ector();
		this.method_1(false);
		this.method_3(true);
	}

	protected override void OnClick(EventArgs e)
	{
		if (this.method_2())
		{
			base.Focus();
		}
		base.OnClick(e);
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		if (this.method_0())
		{
			MouseEventArgs mouseEventArgs = e as MouseEventArgs;
			if (mouseEventArgs != null)
			{
				foreach (object control in base.Controls)
				{
					CheckBox checkBox = control as CheckBox;
					if (checkBox != null && checkBox.Enabled)
					{
						if (mouseEventArgs.Button == MouseButtons.Left)
						{
							checkBox.Checked = true;
						}
						else if (mouseEventArgs.Button == MouseButtons.Right)
						{
							checkBox.Checked = false;
						}
						else
						{
							checkBox.Checked = !checkBox.Checked;
						}
					}
				}
			}
		}
		base.OnDoubleClick(e);
	}
}
