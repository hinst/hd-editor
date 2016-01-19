using System.Collections.Generic;

namespace hd_editor
{

	class CodeStyler
	{
	
		public Token[] tokens;
		public List<string> lines;
		int tokenIndex;

		public CodeStyler()
		{
		}
		
		public void scrollTo(int topLineIndex)
		{
			tokenIndex = 0;
			for (var i = 0; i < tokens.Length; ++i)
			{
				if (tokens[i].lineNumber < topLineIndex)
				{
					tokenIndex = i;
				}
				else
				{
					break;
				}
			}
		}
		
	}
	
}
