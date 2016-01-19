using System.Collections.Generic;

namespace hd_editor
{

	class CodeStyler
	{
	
		public Token[] tokens;
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
		
		public StyledText getFragment(int lineIndex, int characterIndex)
		{
			
		}
		
		void shiftForward(int lineIndex, int characterIndex)
		{
			while (hasNextToken)
			{
				var nextToken = tokens[tokenIndex + 1];
				if (nextToken.lineNumber <= lineIndex 
					&& nextToken.characterIndexInLine <= characterIndex)
				{
					++tokenIndex;
				}
				else
				{
					break;
				}
			}
		}
		
		bool hasNextToken
		{
			get
			{
				return tokenIndex < tokens.Length - 1;
			}
		}
		
	}
	
}
