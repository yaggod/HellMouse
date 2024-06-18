namespace HellMouse
{
	public static class EnumExtension<T> where T : struct, Enum
	{
		private static T[] _items;
		private static Random _random = new();
		static EnumExtension()
		{
			_items = Enum.GetValues<T>();
		}

		public static T GetRandomItem()
		{
			 return _items[_random.Next(_items.Length)];
		}
	}
}
