using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using NLog;

namespace hd_editor
{

	public class CodeDrawer
	{
	
		public List<string> lines;
		public CharacterStyle makrup;
		public int selectedLine;
		public int selectedCharacter;
		public int characterWidth;
		public int characterHeight;
		Logger log = LogManager.GetCurrentClassLogger();
	
		public void prepare()
		{
			var textBlock = createTextBlock();
			textBlock.Text = "A";
			textBlock.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
			textBlock.Arrange(new Rect(textBlock.DesiredSize));
			characterWidth = (int)textBlock.ActualWidth;
			characterHeight = (int)textBlock.ActualHeight;
			log.Debug("characterWidth=" + characterWidth + " characterHeight=" + characterHeight + " haveFont=" + (codeFont != null));
			debugPrintAvailableFonts();
		}
		
		public void debugPrintAvailableFonts()
		{
			var fonts = Fonts.GetFontFamilies(new Uri("pack://application:,,,/"), "./");
			log.Debug("Number of fonts: " + fonts.Count);
			foreach (var font in fonts)
			{
				log.Debug("font: " + font.BaseUri);
			}
		}
		
		public void draw(Canvas canvas)
		{
			canvas.Children.Clear();
			var lineIndex = selectedLine;
			int top = 0;
			log.Debug("" + canvas.ActualHeight + " " + lines.Count);
			while (top < canvas.ActualHeight && lineIndex < lines.Count)
			{
				var textBlock = createTextBlock();
				textBlock.Text = lines[lineIndex];
				top += characterHeight;
				textBlock.setTop(top);
				canvas.Children.Add(textBlock);
				lineIndex++;
			}
		}
		
		public TextBlock createTextBlock()
		{
			var result = new TextBlock();
			result.FontFamily = codeFont;
			result.FontSize = 14;
			result.TextWrapping = TextWrapping.NoWrap;
			return result;
		}
		
		public static FontFamily codeFont = new FontFamily(new Uri("pack://application:,,,/"), "./#Ubuntu Mono");

	}
	
}
