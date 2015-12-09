using System;
using System.IO;
using System.Collections.Generic;

namespace hd_editor
{

	public class Development
	{
	
		public string path;
		public List<SourceFile> files;
	
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
			this.files = fileList;
		}
		
	}
	
}
