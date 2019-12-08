using System.Collections.Generic;
using System.Drawing;
using WinForms.Library.Models;

namespace Loomer
{
    public class Options 
    {
        public Color WarpColor { get; set; } = Color.Black;
        public Color WeftColor { get; set; } = Color.White;
        public int SquareSize { get; set; } = 5;
        public List<SimpleWeaver.Harness> Patterns { get; set; }
        public bool DrawCoordinates { get; set; }
        public string HarnessOrder { get; set; }

        public FormPosition FormPosition { get; set; }
    }
}
