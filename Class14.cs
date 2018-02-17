using System.Runtime.CompilerServices;

internal class Class14
{
	public int Value
	{
		get;
		set;
	}

	public string Name
	{
		get;
		set;
	}

    int _003CDispNum_003Ek__BackingField;

	[CompilerGenerated]
	public int method_0()
	{
		return this._003CDispNum_003Ek__BackingField;
	}

	[CompilerGenerated]
	public void method_1(int int_0)
	{
		this._003CDispNum_003Ek__BackingField = int_0;
	}

	public Class14(int int_0, int int_1, string string_0)
	{
		
		this.Value = int_1;
		this.method_1(int_0);
		this.Name = string_0;
	}

	public override string ToString()
	{
		if (this.method_0() < 0)
		{
			return this.Name;
		}
		return string.Format("{0:d3}:{1}", this.method_0() + 1, this.Name);
	}
}
