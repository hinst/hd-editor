using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace hd_editor
{

	public class CodeDrawer
	{
	
		public string[] lines;
		public CharacterStyle makrup;
		public int selectedLine;
		public int selectedCharacter;
		public int characterWidth;
		public int characterHeight;
	
		public void prepare()
		{
			var textBlock = createTextBlock();
			textBlock.Text = "A";
			textBlock.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
			textBlock.Arrange(new Rect(textBlock.DesiredSize));
			characterWidth = (int)textBlock.ActualWidth;
			characterHeight = (int)textBlock.ActualHeight;
			Console.WriteLine("" + characterWidth + " " + characterHeight);
		}
		
		public void draw(Canvas canvas)
		{
			canvas.Children.Clear();
			var lineIndex = selectedLine;
			int top = 0;
			while (top < canvas.ActualHeight && lineIndex < lines.Length)
			{
				var textBlock = createTextBlock();
				textBlock.Text = lines[lineIndex];
				top += characterHeight;
			}
		}
		
		public TextBlock createTextBlock()
		{
			var result = new TextBlock();
			result.FontFamily = codeFont;
			result.TextWrapping = TextWrapping.NoWrap;
			return result;
		}
		
		public static FontFamily codeFont = new FontFamily(new Uri("pack://application:,,,/"), "UbuntuMono-R.ttf");

	}
	
}
