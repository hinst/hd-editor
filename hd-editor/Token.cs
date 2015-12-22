
using System;

namespace hd_editor
{

	struct Token
	{
	
		public enum Type
		{
			unit,
			program,
			library,
			begin,
			end,
			space,
			openBrace,
			closeBrace,
			comma,
			dot,
			colon,
			semicolon,
			implementation,
			interfaceKeyword,
			ifKeyword,
			thenKeyword,
			stringThing,
			equalsSign,
			assignSign,
			lessThan,
			greaterThan,
			comment,
			includeFile,
			define,
			undefine,
		}
		
		public Type type;
		public string content;
		public int index;
	
	}
	
}
