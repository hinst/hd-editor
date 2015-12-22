using System;
using System.Collections.Generic;
using System.Text;

namespace hd_editor
{

	class Tokenizer
	{
	
		List<Token> tokens;
		string filePath;
		string text;
		int position;
		
		public void tokenize()
		{
			position = 0;
			if (tokens == null)
			{
				tokens = new List<Token>();
			}
			while (position < text.Length)
			{
				var currentChar = text[position];
				if (PascalLang.isIdentifierStartChar(currentChar))
				{
					grabIdentifier();
				}
			}
		}
		
		void grabIdentifier()
		{
			var identifierText = new StringBuilder();
			while (position < text.Length)
			{
				var currentChar = text[position];
				if (PascalLang.isIdentifierChar(currentChar))
				{
					identifierText.Append(currentChar);
				}
				else
				{
					break;
				}
				++position;
			}
			Token token;
			token.content = identifierText.ToString();
			token.type = Token.Type.identifier;
			// TODO: token.line
			tokens.Add(token);
		}

	}
	
}
