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
			log.Debug("" + lineIndex + ":" + characterIndex 
				+ " [" + tokenIndex + "] " 
				+ textStyle.toString());
			return textStyle;
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
