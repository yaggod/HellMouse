
namespace HellMouse
{
	internal class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			new HellMouse(100, 500).Begin();

			SetupTrayIcon();
		}

		private static void SetupTrayIcon()
		{
			TrayIconContainer form = new TrayIconContainer();
			Application.Run(form);
		}
	}
}
