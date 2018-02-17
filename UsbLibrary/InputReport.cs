namespace UsbLibrary
{
	public abstract class InputReport : Report
	{


		public InputReport(HIDDevice oDev) : base(oDev)
		{
			Class21.mKf3Qywz2M1Yy();
		}

		public void SetData(byte[] arrData)
		{
			base.SetBuffer(arrData);
			this.ProcessData();
		}

		public abstract void ProcessData();
	}
}
