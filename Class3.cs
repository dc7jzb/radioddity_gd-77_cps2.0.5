using System;
using System.Windows.Forms;

internal class Class3 : Panel
{
	protected override void OnClick(EventArgs e)
	{
		base.Focus();
		base.OnClick(e);
	}

	public Class3() : base()
	{
		
		////base._002Ector();
	}
}
