using System;
using System.Collections;
using System.Windows.Forms;

internal class Class4 : ComboBox
{
	private Hashtable ItemList;

	public Class4():base()
	{
		
		this.ItemList = new Hashtable();
		//base._002Ector();
	}

	public void method_0()
	{
		base.Items.Clear();
		this.ItemList.Clear();
	}

	public void method_1(string string_0, int int_0)
	{
		int num = base.Items.Add(new Class5(string_0, int_0));
		if (!this.ItemList.Contains(int_0))
		{
			this.ItemList.Add(int_0, num);
		}
	}

	public void method_2(int int_0)
	{
		if (this.ItemList.ContainsKey(int_0))
		{
			this.SelectedIndex = int.Parse(this.ItemList[int_0].ToString());
		}
		else if (base.Items.Count > 0)
		{
			this.SelectedIndex = 0;
		}
		else
		{
			this.SelectedIndex = -1;
		}
	}

	public int method_3()
	{
		Class5 @class = base.SelectedItem as Class5;
		if (@class != null)
		{
			return Convert.ToInt32(@class.Value);
		}
		return 0;
	}
}
