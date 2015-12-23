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
		int lineNumber;
		bool subFileMode;
		
		public void tokenize()
		{
			position = 0;
			lineNumber = 1;
			if (tokens == null)
			{
				tokens = new List<Token>();
			}
			else
			{
				subFileMode = true;
			}
			while (position < text.Length)
			{
				var currentChar = text[position];
				if (currentChar == (char)10)
				{
				
				}
				else if (PascalLang.isIdentifierStartChar(currentChar))
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
			Token token = new Token();
			token.content = identifierText.ToString();
			token.type = Token.Type.identifier;
			addToken(token);
		}
		
		void addToken(Token token)
		{
			token.position = position;
			token.lineNumber = lineNumber;
			tokens.Add(token);
		}

	}
	
}
