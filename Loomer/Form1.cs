using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loomer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            const int size = 50;

            var purple = Brushes.BlueViolet;
            var gold = Brushes.Goldenrod;
                       
            int width = splitContainer1.Panel2.ClientRectangle.Width / size;
            int height = splitContainer1.Panel2.ClientRectangle.Height / size;

            var patterns = new[]
            {
                new { Pattern = CreatePattern(1, 4, width)},
                new { Pattern = CreatePattern(2, 4, width)},
                new { Pattern = CreatePattern(3, 4, width)},
                new { Pattern = CreatePattern(4, 4, width)}
            };

            using (var g = splitContainer1.Panel2.CreateGraphics())
            {
                for (int y = 1; y < height; y++)
                {
                    int index = (y - 1) % patterns.Length;
                    var pattern = patterns[index];

                    for (int x = 1; x < width; x++)
                    {
                        if (pattern.Pattern.Contains(x))
                        {
                            DrawBox(g, size, x, y, purple);
                        }
                        else
                        {
                            DrawBox(g, size, x, y, gold);
                        }
                    }
                }
            }
        }

        private IEnumerable<int> CreatePattern(int start, int interval, int max)
        {
            List<int> results = new List<int>();
            int value = start;
            results.Add(start);
            while (value < max)
            {
                value += interval;
                results.Add(value);
            }
            return results;
        }

        private void DrawBox(Graphics g, int size, int x, int y, Brush brush)
        {
            var rect = new Rectangle(new Point((x - 1) * size, (y - 1) * size), new Size(x * size, y * size));
            g.FillRectangle(brush, rect);
            g.DrawString($"{x}|{y}", this.Font, Brushes.Black, rect);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            using (var g = splitContainer1.Panel2.CreateGraphics())
            {
                g.Clear(splitContainer1.Panel2.BackColor);
            }
        }        
    }
}
