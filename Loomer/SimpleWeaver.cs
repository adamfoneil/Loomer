using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Loomer
{
    /// <summary>
    /// a 2-color weaver
    /// </summary>
    public class SimpleWeaver
    {
        private readonly Control _control;

        public SimpleWeaver(Control drawingSurface)
        {
            _control = drawingSurface;
        }

        public Brush WarpColor { get; set; }
        public Brush WeftColor { get; set; }
        public int SquareSize { get; set; }
        public Font Font { get; set; } 
        public Harness[] Harnesses { get; set; }
        public string HarnessOrder { get; set; }
        public bool DrawCoordinates { get; set; }

        public void Draw()
        {
            int width = _control.ClientRectangle.Width / SquareSize;
            int height = _control.ClientRectangle.Height / SquareSize;

            if (string.IsNullOrEmpty(HarnessOrder))
            {
                HarnessOrder = string.Join("", Harnesses.Select(h => h.Letter));
            }

            var harnessOrder =
                (from h in Harnesses
                join o in HarnessOrder.ToCharArray() on h.Letter.ToLower() equals o.ToString().ToLower()
                select h).ToArray();

            using (Graphics g = _control.CreateGraphics())
            {
                for (int y = 1; y < height; y++)
                {
                    int index = (y - 1) % harnessOrder.Length;
                    var pattern = CreatePattern(harnessOrder[index], width);

                    for (int x = 1; x < width; x++)
                    {
                        if (pattern.Contains(x))
                        {
                            DrawBox(g, x, y, WarpColor);
                        }
                        else
                        {
                            DrawBox(g, x, y, WeftColor);
                        }
                    }
                }
            }
        }

        private void DrawBox(Graphics g, int x, int y, Brush brush)
        {
            var rect = new Rectangle(new Point((x - 1) * SquareSize, (y - 1) * SquareSize), new Size(x * SquareSize, y * SquareSize));
            g.FillRectangle(brush, rect);

            if (DrawCoordinates)
            {
                g.DrawString($"{x},{y}", Font, Brushes.Black, rect);
            }            
        }

        public static int[] CreatePattern(Harness harness, int max)
        {
            if (harness.Interval < 1) throw new ArgumentException("Harness interval must be greater than zero.");
            if (harness.StartValue < 1) throw new ArgumentException("Harness start value must be greater than zero.");

            List<int> results = new List<int>();
            int value = harness.StartValue;
            results.Add(value);
            while (value < max)
            {
                value += harness.Interval;
                results.Add(value);
            }
            return results.ToArray();
        }

        public static string[] HarnessLetters
        {
            get
            {
                char a = 'A';
                return Enumerable.Range((int)a, 26).Select(i => Convert.ToChar(i).ToString()).ToArray();
            }
        }

        public void AlertUnusedHarnesses(DataGridView dataGridView)
        {
            throw new NotImplementedException();
        }

        public class Harness
        {
            public Harness()
            {
            }

            public Harness(int startValue, int interval)
            {
                StartValue = startValue;
                Interval = interval;
            }

            public string Letter { get; set; }
            public int StartValue { get; set; }
            public int Interval { get; set; }
        }
    }
}
