using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using NLog;
using System.Diagnostics;

namespace hd_editor
{

	class CodeDrawer
	{

		SourceFile sourceFile;
		public int selectedLine;
		public int selectedCharacter;
		public int characterWidth;
		public int characterHeight;
		public int scrollX;
		public int scrollY;
		public Canvas canvas;
		public static FontFamily codeFont = 
			new FontFamily(new Uri("pack://application:,,,/"), "./#Ubuntu Mono");		
		Logger log = LogManager.GetCurrentClassLogger();
	
		public void prepare()
		{
			var textBlock = createTextBlock();
			textBlock.Text = "A";
			textBlock.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
			textBlock.Arrange(new Rect(textBlock.DesiredSize));
			characterWidth = (int)textBlock.ActualWidth;
			characterHeight = (int)textBlock.ActualHeight;
			log.Debug("characterWidth=" + characterWidth 
				+ " characterHeight=" + characterHeight 
				+ " haveFont=" + (codeFont != null));
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
			if (sourceFile != null)
			{
				var lineIndex = scrollY;
				int topPixel = 0;
				while (topPixel < canvas.ActualHeight && lineIndex < sourceFile.lines.Count)
				{
					var textBlock = drawLine(lineIndex);
					textBlock.setTop(topPixel);
					canvas.Children.Add(textBlock);
					topPixel += characterHeight;
					lineIndex++;
				}
			}
		}
		
		TextBlock drawLine(int lineIndex)
		{
			var textBlock = createTextBlock();
			var text = sourceFile.lines[lineIndex];
			if (scrollX > 0)
			{
				text = text.Substring(scrollX);
			}
			textBlock.Text = text;
			return textBlock;
		}
		
		TextBlock createTextBlock()
		{
			var result = new TextBlock();
			result.FontFamily = codeFont;
			result.FontSize = 14;
			result.TextWrapping = TextWrapping.NoWrap;
			return result;
		}
		
		public void scrollByPixels(int delta)
		{
			delta = delta / characterHeight;
			delta = (-1) * delta;
			scrollY += delta;
			if (scrollY < 0)
				scrollY = 0;
			if (sourceFile != null)
			{
				if (sourceFile.lines.Count <= scrollY)
				{
					scrollY = sourceFile.lines.Count;
				}
			}
		}
		
		public void changeSourceFile(SourceFile sourceFile)
		{
			this.sourceFile = sourceFile;
		}
		
	}
	
}
