using System.Windows.Media;

namespace hd_editor
{

	struct TextStyle
	{
	
		public Color textColor;
		public bool bold;
		
		public bool equals(TextStyle textStyle)
		{
			return textColor.Equals(textStyle.textColor)
				&& bold == textStyle.bold;
		}
		
		public string toString()
		{
			return "color=" + textColor + " bold=" + bold;
		}
	
	}
	
}
