
using System;

namespace hd_editor
{

	public struct Token
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
		
		Type type;
		string content;
		int index;
	
	}
	
}
