internal class Class5
{
	private string _text;

	private object _value;

	public string Text
	{
		get
		{
			return this._text;
		}
		set
		{
			this._text = value;
		}
	}

	public object Value
	{
		get
		{
			return this._value;
		}
		set
		{
			this._value = value;
		}
	}

	public override string ToString()
	{
		return this._text;
	}

	public Class5(string string_0, object object_0)
	{
		Class21.mKf3Qywz2M1Yy();
		//base._002Ector();
		this._text = string_0;
		this._value = object_0;
	}
}
