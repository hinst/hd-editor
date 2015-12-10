using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace hd_editor
{

	public class SourceFile
	{
	
		public bool isSourceFile
		{
			get
			{
				return path.EndsWith(".pas", StringComparison.OrdinalIgnoreCase);
			}
		}
	
		public SourceFile()
		{
		}
		
		public string path;
		public List<string> lines;
		public CharacterStyle[,] markup;
		
		public void load()
		{
			var content = File.ReadAllText(path, Encoding.UTF8);
			lines = getLines(content);
		}
		
		public static List<string> getLines(string text)
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
		
	}
	
}
