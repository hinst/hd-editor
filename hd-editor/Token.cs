
using System;

namespace hd_editor
{

	public struct Token
	{
	
		public enum Type
		{
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
			comment
		}
		
		Type type;
		string content;
		int index;
	
	}
	
}
