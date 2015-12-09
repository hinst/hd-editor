
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace hd_editor
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
	
		public Development development = new Development();
	
		public Window1()
		{
			InitializeComponent();
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
				itemTag.sourceFile = file;
				item.Tag = itemTag;
				fileList.Items.Add(item);
			}
		}
		
		void refreshDevelopment()
		{
			development.scan();
			Console.WriteLine(development.files.Count);
			loadFileList();
		}
		
		void FileList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (fileList.SelectedIndex >= 0)
			{
				var item = (ListBoxItem)fileList.Items[fileList.SelectedIndex];
				var tagItem = (FileListItemTag)item.Tag;
			}
		}
		
	}
	
}