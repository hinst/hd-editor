using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace hd_editor
{

	public class CodeDrawer
	{
	
		public string[] lines;
		public CharacterStyle makrup;
		public int currentLine;
		public int currentCharacter;
	
		public void draw(Canvas canvas)
		{
			canvas.Children.Clear();
			var textBlock = createTextBlock();
			textBlock.Text = "heh";
			canvas.Children.Add(textBlock);
		}
		
		public TextBlock createTextBlock()
		{
			var result = new TextBlock();
			result.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "UbuntuMono-R.ttf");
			return result;
		}
		
	}
	
}
