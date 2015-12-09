using System.Collections.Generic;
using System.IO;

namespace hd_editor
{

	public class SourceFiles
	{
	
		public string path;
		public SourceFile[] files;
	
		public SourceFiles()
		{
		}
		
		public void scan()
		{
			var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
			var fileList = new List<SourceFile>(files.Length);
			foreach (var file	in files)
			{
				var repoFile = new SourceFile();
				repoFile.path = file;
				if (repoFile.isSourceFile)
				{
					fileList.Add(repoFile);
				}
			}
			this.files = fileList.ToArray();
		}
		
	}
	
}
