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
			while(true)
			{
				try
				{
					PerformAction();
					Task.Delay(random.Next(MinDelay, MaxDelay)).Wait();
				}
				catch
				{
				}
			}
		}

		private static void PerformAction()
		{
			Random random = new();
			MouseEvent mouseEvent = EnumExtension<MouseEvent>.GetRandomItem();
			Rectangle? screenBounds = Screen.PrimaryScreen?.Bounds;
			int x = random.Next(0, screenBounds?.Width ?? 0);
			int y = random.Next(0, screenBounds?.Height ?? 0);
			WinApi.mouse_event(mouseEvent);
			WinApi.SetCursorPos(x, y);
		}
	}
}
