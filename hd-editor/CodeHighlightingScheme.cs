using System.Collections.Generic;

namespace hd_editor
{

	class CodeHighlightingScheme
	{
	
		readonly Dictionary<Token.Type, TextStyle> map = new Dictionary<Token.Type, TextStyle>();
		
		public static CodeHighlightingScheme defaultScheme
		{
			get
			{
				var scheme = new CodeHighlightingScheme();
				var keywordStyle = new TextStyle();
				keywordStyle.bold = true;
				scheme.map.Add(Token.Type.keyword, keywordStyle);
				return scheme;
			}
		}
		
		public TextStyle getStyle(Token.Type tokenType)
		{
			TextStyle textStyle = new TextStyle();
			map.TryGetValue(tokenType, out textStyle);
			return textStyle;
		}
	
	}
	
}
