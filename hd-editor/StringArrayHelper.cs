using System.Text;
using System;

namespace hd_editor
{

	static class StringArrayHelper
	{
	
		public static string toString(this string[] stringArray, string separator)
		{
			var text = new StringBuilder();
			for (var i = 0; i < stringArray.Length; i++)
			{
				text.Append(stringArray[i]);
				if (i != stringArray.Length - 1)
				{
					text.Append(separator);
				}
			}
			return text.ToString();
		}
		
	}
	
}
