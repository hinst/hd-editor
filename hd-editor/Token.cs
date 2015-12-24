
using System;

namespace hd_editor
{

	struct Token
	{
	
		public enum Type
		{
			identifier,
			keyword,
			lineBreak,
			space,
			openBrace,
			closeBrace,
			comma,
			dot,
			colon,
			semicolon,
			stringThing,
			equalsSign,
			assignSign,
			lessThan,
			greaterThan,
			comment,
			includeFile,
			define,
			undefine,
			unknown,
		}
		
		public Type type;
		public string content;
		public int position;
		public int positionInLine;
		public int lineNumber;
	
	}
	
}
