using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace hd_editor
{

	public partial class App : Application
	{
	
		void Application_Startup(object sender, StartupEventArgs e)
		{
			var window = new Window1();
			if (e.Args.Length > 0)
			{
				window.development.files.path = e.Args[0];
			}
			window.Show();
		}
		
	}
	
}