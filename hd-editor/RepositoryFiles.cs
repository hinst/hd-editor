using System.Collections.Generic;
using System.IO;

namespace hd_editor
{

	public class RepositoryFiles
	{
	
		public string path;
		public RepositoryFile[] files;
	
		public RepositoryFiles()
		{
		}
		
		public void scan()
		{
			var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
			var fileList = new List<RepositoryFile>(files.Length);
			foreach (var file	in files)
			{
				var repoFile = new RepositoryFile();
				repoFile.filePath = file;
				if (repoFile.isRepoFile)
				{
					fileList.Add(repoFile);
				}
			}
			this.files = fileList.ToArray();
		}
		
	}
	
}
