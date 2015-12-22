
using System;

namespace hd_editor
{

	static class PascalLang
	{
	
		public const string letters = 
			"abcdefghijklmnopqrstuvwxyz_ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		public const string numbers = "0123456789";
		public const string lettersNumbers = letters + numbers;
		
		public static bool isIdentifierChar(char c)
		{
			return lettersNumbers.IndexOf(c) != -1;
		}
		
		public static bool isIdentifierStartChar(char c)
		{
			return letters.IndexOf(c) != -1;
		}
		
	}
	
}
