using System;
using System.Windows;
using System.Windows.Controls;

namespace hd_editor
{

	static class CanvasHelper
	{
	
		public static void setLeft(this DependencyObject o, double value)
		{
			o.SetValue(Canvas.LeftProperty, value);
		}
		
		public static void setTop(this DependencyObject o, double value)
		{
			o.SetValue(Canvas.TopProperty, value);
		}
		
	}
	
}
