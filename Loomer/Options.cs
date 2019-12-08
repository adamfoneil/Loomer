using System.Collections.Generic;
using System.Drawing;

namespace Loomer
{
    public class Options 
    {
        public Color WarpColor { get; set; } = Color.Black;
        public Color WeftColor { get; set; } = Color.White;
        public int SquareSize { get; set; } = 1;
        public List<SimpleWeaver.PatternRule> Patterns { get; set; }
        public bool DrawCoordinates { get; set; }
    }
}
