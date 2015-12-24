using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NLog;

namespace hd_editor
{

	class Tokenizer
	{
	
		public List<Token> tokens;
		string filePath;
		public string text;
		int position;
		int lineNumber;
		bool subFileMode;
		readonly Logger log;
		
		public Tokenizer()
		{
			log = this.getLogger();
		}
		
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
				if (currentChar == (char)13)
				{
					++position;
				}
				else if (currentChar == (char)10)
				{
					var token = new Token();
					token.type = Token.Type.lineBreak;
					++lineNumber;
					++position;
				}
				else if (PascalLang.isIdentifierStartChar(currentChar))
				{
					grabIdentifier();
				}
				else
				{
					++position;
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
			if (PascalLang.isKeyword(token.content))
				token.type = Token.Type.keyword;
			else
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
