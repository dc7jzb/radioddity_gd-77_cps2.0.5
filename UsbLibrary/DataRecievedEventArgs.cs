using System;

namespace UsbLibrary
{
	public class DataRecievedEventArgs : EventArgs
	{
		public readonly byte[] data;

		public DataRecievedEventArgs(byte[] data)
		{
			Class21.mKf3Qywz2M1Yy();
			//base._002Ector();
			this.data = data;
		}
	}
}
