﻿using System.Linq;

namespace hd_editor
{

	static class PascalLang
	{
	
		public const string letters = 
			"abcdefghijklmnopqrstuvwxyz_ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		public const string numbers = "0123456789";
		public const string lettersNumbers = letters + numbers;
		public static readonly string[] keywords = 
		{
			"begin", "end", "initialization", "finalization",
			"var", "const",
			"if", "then", "else", "case",
			"program", "unit", "library",
			"interface", "implementation", "uses",
			"function", "procedure",
			"try", "except", "finally",
			"type", "class", "record", "object", "interface",
			"private", "protected", "public", "published",
		};
			
		public static bool isIdentifierChar(char c)
		{
			return lettersNumbers.IndexOf(c) != -1;
		}
		
		public static bool isIdentifierStartChar(char c)
		{
			return letters.IndexOf(c) != -1;
		}
		
		public static bool isKeyword(string word)
		{
			return keywords.Contains(word.ToLower());
		}
		
	}
	
}
