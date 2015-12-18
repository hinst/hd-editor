using System;

namespace hd_editor
{

	public static class F
	{
	
		public static T choose<T>(bool condition, Func<T> positive, Func<T> negative)
		{
			if (condition)
				return positive();
			else
				return negative();
		}
	
	}
	
}
