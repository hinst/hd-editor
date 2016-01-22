using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NLog;
using System.Linq;

namespace hd_editor
{

	class SourceFile
	{
	
		public bool isSourceFile
		{
			get
			{
				return path.EndsWith(".pas", StringComparison.OrdinalIgnoreCase);
			}
		}
	
		public string path;
		public List<string> lines;
		public Token[] tokens;
		Logger log;
		
		public SourceFile()
		{
			log = this.getLogger();
		}
		
		public void load()
		{
			var content = File.ReadAllText(path, Encoding.UTF8);
			lines = loadLines(content);
			tokens = loadTokens(content);
			saveTokensText();
		}
		
		List<string> loadLines(string text)
		{
			var lines = new List<string>();
			var line = new StringBuilder();
			for (var i = 0; i < text.Length; i++)
			{
				var character = text[i];
				if (character == (char)10)
				{
					lines.Add(line.ToString());
					line.Clear();
				}
				else if (character != (char)13)
				{
					line.Append(character);
				}
			}
			return lines;
		}
		
		Token[] loadTokens(string text)
		{
			var tokenizer = new Tokenizer();
			tokenizer.text = text;
			tokenizer.tokenize();
			var tokens = tokenizer.tokens.ToArray();
			log.Debug("loadTokens: tokens.Length=" + tokens.Length);
			return tokens;
		}
		
		public void saveTokensText()
		{
			var text = String.Join("\r\n", tokens.Select(token => token.toString()));
			File.WriteAllText(path + ".tokens", text);
		}
		
	}
	
}
