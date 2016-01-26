using System.Diagnostics;
using NLog;

namespace hd_editor
{

	class CodeStyler
	{
	
		public Token[] tokens;
		int tokenIndex;
		CodeHighlightingScheme scheme;
		Logger log;

		public CodeStyler()
		{
			scheme = CodeHighlightingScheme.defaultScheme;
			log = this.getLogger();
		}
		
		public void scrollTo(int topLineIndex)
		{
			tokenIndex = 0;
			if (tokens != null)
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
			log.Debug("scrollTo: " + topLineIndex + " -> " + tokenIndex);
		}
		
		public TextStyle getTextStyle(int lineIndex, int characterIndex)
		{
			shiftForward(lineIndex, characterIndex);
			var textStyle = new TextStyle();
			if (0 <= tokenIndex && tokenIndex < tokens.Length) 
			{
				var token = tokens[tokenIndex];
				textStyle = scheme.getStyle(token.type);
			}
			return textStyle;
		}
		
		void shiftForward(int lineIndex, int characterIndex)
		{
			while (tokenIndex < tokens.Length - 1)
			{
				var nextToken = tokens[tokenIndex + 1];
				var closer = nextToken.lineNumber < lineIndex 
					|| nextToken.lineNumber == lineIndex 
						&& nextToken.characterIndexInLine <= characterIndex;
				if (closer)
				{
					++tokenIndex;
				}
				else
				{
					break;
				}
			}
		}
		
	}
	
}
