namespace UsbLibrary
{
	public class SpecifiedInputReport : InputReport
	{
		private byte[] arrData;

		public byte[] Data
		{
			get
			{
				return this.arrData;
			}
		}

		public SpecifiedInputReport(HIDDevice oDev) : base (oDev)
		{
			//Class21.mKf3Qywz2M1Yy();
		}

		public override void ProcessData()
		{
			this.arrData = base.Buffer;
		}
	}
}
