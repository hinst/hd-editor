
using System;

namespace hd_editor
{

	public class RepositoryFile
	{
	
		public string filePath;
		
		public RepositoryFile()
		{
		
		}
		
		public bool isRepoFile
		{
			get
			{
				return filePath.EndsWith(".pas", StringComparison.OrdinalIgnoreCase);
			}
		}
		
	}
	
}
