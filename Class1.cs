using System;
using System.Diagnostics;

internal class Class1 : Stopwatch, IDisposable
{
	public Class1() : base()
	{
//		Class21.mKf3Qywz2M1Yy();
		base.Start();
	}

	public void Dispose()
	{
		base.Stop();
		Console.WriteLine("Elapsed: {0} ms", base.ElapsedMilliseconds);
	}
}
