using System;
using System.Text;

internal class Class7
{
	public static string smethod_0(string string_0)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(string_0);
		return Convert.ToBase64String(bytes);
	}

	public static string smethod_1(string string_0)
	{
		byte[] bytes = Convert.FromBase64String(string_0);
		return Encoding.UTF8.GetString(bytes);
	}

	public Class7()
	{
		
		//base._002Ector();
	}
}
