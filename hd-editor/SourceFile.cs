using System;

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
		public string[] lines;
		public CharacterStyle[,] markup;
		
		public void load()
		{
		}
		
	}
	
}
