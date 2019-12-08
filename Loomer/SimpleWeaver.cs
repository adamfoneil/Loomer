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
        public PatternRule[] Patterns { get; set; }
        public bool DrawCoordinates { get; set; }

        public void Draw()
        {
            int width = _control.ClientRectangle.Width / SquareSize;
            int height = _control.ClientRectangle.Height / SquareSize;

            using (Graphics g = _control.CreateGraphics())
            {
                for (int y = 1; y < height; y++)
                {
                    int index = (y - 1) % Patterns.Length;
                    var pattern = CreatePattern(Patterns[index], width);

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

        private static int[] CreatePattern(PatternRule rule, int max)
        {
            if (rule.Interval < 1) throw new ArgumentException("Pattern interval must be greater than zero.");
            if (rule.StartValue < 1) throw new ArgumentException("Pattern start value must be greater than zero.");

            List<int> results = new List<int>();
            int value = rule.StartValue;
            results.Add(value);
            while (value < max)
            {
                value += rule.Interval;
                results.Add(value);
            }
            return results.ToArray();
        }

        public class PatternRule
        {
            public PatternRule()
            {
            }

            public PatternRule(int startValue, int interval)
            {
                StartValue = startValue;
                Interval = interval;
            }

            public int StartValue { get; set; }
            public int Interval { get; set; }
        }
    }
}
