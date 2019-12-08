using System.Drawing;

namespace Loomer
{
	public class ColorOption
	{
		public ColorOption()
		{
		}

		public ColorOption(Color color)
		{
			Color = color;
			Name = color.Name;
		}

		public string Name { get; set; }
		public Color Color { get; set; }

		public override string ToString()
		{
			return Name;
		}

		public Brush ToBrush()
		{
			return new SolidBrush(Color);
		}

		public override bool Equals(object obj)
		{
			var test = (obj as ColorOption);
			return (test != null) ? test.Color.Equals(this.Color) : false;
		}

		public override int GetHashCode()
		{
			return Color.GetHashCode();
		}
	}
}
