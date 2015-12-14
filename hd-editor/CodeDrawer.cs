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

		public SourceFile sourceFile;
		public int selectedLine;
		public int selectedCharacter;
		public int characterWidth;
		public int characterHeight;
		public Canvas canvas;
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
		
		public void draw()
		{
			canvas.Children.Clear();
			var lineIndex = selectedLine;
			int top = 0;
			log.Debug("" + canvas.ActualHeight + " " + sourceFile.lines.Count);
			while (top < canvas.ActualHeight && lineIndex < sourceFile.lines.Count)
			{
				var textBlock = createTextBlock();
				textBlock.Text = sourceFile.lines[lineIndex];
				top += characterHeight;
				textBlock.setTop(top);
				canvas.Children.Add(textBlock);
				lineIndex++;
			}
		}
		
		public TextBlock[] drawLine(int lineIndex)
		{
			var textBlocks = new List<TextBlock>();
			var x = 0;
			while (x + characterWidth < canvas.ActualWidth)
			{
				
			}
			return textBlocks.ToArray();
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
