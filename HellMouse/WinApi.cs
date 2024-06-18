using System.Runtime.InteropServices;

namespace HellMouse
{
	public class WinApi
	{
		[DllImport("User32.Dll")]
		public static extern long SetCursorPos(int x, int y);

		[DllImport("user32.dll")]
		public static extern void mouse_event(MouseEvent dwFlags);
		// original signature looks like this: 
		//public static extern void mouse_event(uint dwFlags, uint dx = 0, uint dy = 0, uint cButtons = 0, uint dwExtraInfo = 0);

	}

	public enum MouseEvent
	{
		NONE = 0x00,
		MOUSEEVENTF_LEFTDOWN = 0x02,
		MOUSEEVENTF_LEFTUP = 0x04,
		MOUSEEVENTF_RIGHTDOWN = 0x08,
		MOUSEEVENTF_RIGHTUP = 0x10,
		MOUSEEVENTF_MIDDLEDOWN = 0x20,
		MOUSEEVENTF_MIDDLEUP = 0x40,
	}
}
