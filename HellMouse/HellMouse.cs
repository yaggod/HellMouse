using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellMouse
{
	internal class HellMouse
	{
		public int MinDelay { get; private set; }
		public int MaxDelay { get; private set; }

		private Thread _executionThread;


		public HellMouse(int minDelay, int maxDelay)
		{
			MinDelay = minDelay;
			MaxDelay = maxDelay;
			_executionThread = new Thread(Workflow);
		}

		public void Begin()
		{
			_executionThread.Start();
		}

		public void Stop()
		{

		}

		private void Workflow()
		{
			Random random = new();
			for(int i = 0; i < 5; i++)
			//while(true)
			{
				PerformAction();
				Task.Delay(random.Next(MinDelay, MaxDelay)).Wait();
            }
        }

		private static void PerformAction()
		{
			Random random = new();
			MouseEvent mouseEvent = EnumExtension<MouseEvent>.GetRandomItem();
			int x = random.Next(0, 1920);
			int y = random.Next(0, 1080);

			Console.WriteLine($"{mouseEvent} {x} {y}");
			WinApi.SetCursorPos(x, y);
            WinApi.mouse_event((uint) mouseEvent);
		}
	}
}
