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
            var weaver = new SimpleWeaver(splitContainer1.Panel2)
            {
                Font = this.Font,
                SquareSize = 50,
                WarpColor = Brushes.BlueViolet,
                WeftColor = Brushes.Goldenrod,
                Patterns = new SimpleWeaver.PatternRule[]
                {
                    new SimpleWeaver.PatternRule(1, 4),
                    new SimpleWeaver.PatternRule(2, 4),
                    new SimpleWeaver.PatternRule(3, 4),
                    new SimpleWeaver.PatternRule(4, 4)
                }
            };

            weaver.Draw();
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
