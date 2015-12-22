using NLog;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace hd_editor
{

	partial class Window1 : Window
	{
	
		internal Development development = new Development();
		internal CodeDrawer codeDrawer = new CodeDrawer();
		Logger log = LogManager.GetCurrentClassLogger();
	
		public Window1()
		{
			InitializeComponent();
			codeDrawer.canvas = codeCanvas;
			codeDrawer.prepare();
		}
		
		void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.F5)
			{
				refreshDevelopment();
			}
		}
		
		void loadFileList()
		{
			fileList.Items.Clear();
			foreach (var file in development.files)
			{
				var item = new ListBoxItem();
				item.Content = file.path;
				var itemTag = new FileListItemTag();
				itemTag.path = file.path;
				item.Tag = itemTag;
				fileList.Items.Add(item);
			}
		}
		
		void refreshDevelopment()
		{
			development.scan();
			log.Debug("Number of development files found: " + development.files.Count);
			loadFileList();
		}
		
		void FileList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (fileList.SelectedIndex >= 0)
			{
				var item = (ListBoxItem)fileList.Items[fileList.SelectedIndex];
				var tagItem = (FileListItemTag)item.Tag;
				switchToFile(tagItem.path);
			}
		}
		
		void switchToFile(string path)
		{
			var sourceFile = development.getSourceFileByPath(path);
			sourceFile.load();
			codeDrawer.changeSourceFile(sourceFile);
			codeDrawer.draw();
		}
		
		void CodeCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			codeDrawer.scrollByPixels(e.Delta);
			codeDrawer.draw();
		}
		
	}
	
}