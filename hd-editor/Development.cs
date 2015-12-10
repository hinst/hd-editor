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
		
		public SourceFile getSourceFileByPath(string path)
		{
			SourceFile result = null;
			foreach (var file in files)
			{
				if (String.Equals(file.path, path, StringComparison.OrdinalIgnoreCase))
				{
					result = file;
				}
			}
			return result;
		}
		
	}
	
}
