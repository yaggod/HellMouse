namespace HellMouse
{
	internal class HellMouse
	{
		public int MinDelay { get; private set; }
		public int MaxDelay { get; private set; }

		private Thread _executionThread;
		private ManualResetEvent _resetEvent = new(true);


		public HellMouse(int minDelay, int maxDelay)
		{
			MinDelay = minDelay;
			MaxDelay = maxDelay;
			_executionThread = new Thread(Workflow);
		}

		public void Begin()
		{
			if (_executionThread.ThreadState == ThreadState.Running)
				throw new InvalidOperationException("Thread is already running");
			_executionThread.Start();
			
		}

		public void Pause()
		{
			_resetEvent.Reset();
		}
		
		public void Resume()
		{
			_resetEvent.Set();
		}

		private void Workflow()
		{
			Random random = new();
			while(true)
			{
				try
				{
					_resetEvent.WaitOne();
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
