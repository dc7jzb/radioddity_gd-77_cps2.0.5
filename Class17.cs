using DMR;
using System;
using System.Windows.Forms;

internal static class Class17
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Class21.mKf3Qywz2M1Yy();
		Application.Run(new MainForm());
	}

	private static void smethod_0(Exception exception_0)
	{
		MessageBox.Show(exception_0.Message + "\r\n" + exception_0.StackTrace, "");
	}
}
