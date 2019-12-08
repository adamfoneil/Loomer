using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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

        private HashSet<Point> _warpSquares;

        public void Draw()
        {
            int width = _control.ClientRectangle.Width / SquareSize;
            int height = _control.ClientRectangle.Height / SquareSize;            

            if (AnyDuplicateHarnessLetters(out string letters)) throw new ArgumentException($"Can't have duplicate harness letter: {letters}");

            SetDefaultHarnessOrder();

            var harnessGroups = GetHarnessGroups();
            var allHarnesses = Harnesses.ToDictionary(row => row.Letter.ToLower());
            
            _warpSquares = new HashSet<Point>();

            using (Graphics g = _control.CreateGraphics())
            {
                for (int y = 1; y < height; y++)
                {
                    int index = (y - 1) % harnessGroups.Count;

                    foreach (var harnessLetter in harnessGroups[index])
                    {
                        var pattern = allHarnesses[harnessLetter].GetPattern(width);                        

                        for (int x = 1; x < width; x++)
                        {
                            if (pattern.Contains(x))
                            {
                                DrawBox(g, x, y, WarpColor);
                                _warpSquares.Add(new Point(x, y));
                            }
                            else
                            {
                                if (!HasWarp(x, y))
                                {
                                    DrawBox(g, x, y, WeftColor);
                                }                                
                            }
                        }
                    }                                        
                }
            }
        }

        private bool HasWarp(int x, int y)
        {
            return _warpSquares.Contains(new Point(x, y));
        }

        private Dictionary<int, string[]> GetHarnessGroups()
        {
            var groups = HarnessOrder.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
            var indexedGroups = groups.Select((group, index) => new 
            {
                Index = index,
                GroupChars = group.ToCharArray().Select(c => c.ToString().ToLower())
            });

            return indexedGroups.ToDictionary(row => row.Index, row => row.GroupChars.ToArray());
        }

        private void SetDefaultHarnessOrder()
        {
            if (string.IsNullOrEmpty(HarnessOrder))
            {
                HarnessOrder = string.Join(", ", Harnesses.Select(h => h.Letter.ToLower()));
            }
        }

        private bool AnyDuplicateHarnessLetters(out string letters)
        {
            var dups = Harnesses.Select(h => h.Letter.ToLower()).GroupBy(s => s).Where(grp => grp.Count() > 1).Select(grp => grp.Key);
            
            if (dups.Any())
            {
                letters = string.Join(", ", dups);
                return true;
            }

            letters = null;
            return false;
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
            SetDefaultHarnessOrder();

            var harnessesDefined = Harnesses.Select(h => h.Letter.ToLower());
            var harnessesInUse = HarnessOrder.ToCharArray().Select(c => c.ToString().ToLower());
            var unused = harnessesDefined.Except(harnessesInUse);
                        
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                row.ErrorText = null;
                if (unused.Contains(row.Cells["colLetter"].Value.ToString().ToLower()))
                {                                   
                    row.ErrorText = "Your pattern doesn't use this harness";
                }
            }            
        }

        public class Harness
        {
            public Harness()
            {
            }

            public Harness(int startValue, string pattern)
            {
                StartValue = startValue;
                Pattern = pattern;
            }

            public string Letter { get; set; }
            public int StartValue { get; set; }
            public string Pattern { get; set; }

            public int[] GetPattern(int max)
            {
                return (int.TryParse(Pattern, out int interval)) ?
                    SimplePattern(interval, max) :
                    ComplexPattern(max);
            }

            private int[] ComplexPattern(int max)
            {
                var matches = Regex.Matches(Pattern, @"[+|-]\d");
                
                List<int> results = new List<int>();

                int value = StartValue;
                while (value < max)
                {
                    foreach (var match in matches.OfType<Match>())
                    {
                        int count = ParseNumbers(match.Value);
                        if (match.Value.StartsWith("+"))
                        {
                            results.AddRange(Enumerable.Range(value + 1, count));
                            value += count;
                        }

                        if (match.Value.StartsWith("-"))
                        {
                            value += count;
                        }
                    }
                }

                return results.ToArray();
            }

            private int ParseNumbers(string value)
            {
                return int.Parse(string.Join("", value.ToCharArray().Where(c => char.IsNumber(c))));
            }

            private int[] SimplePattern(int interval, int max)
            {
                if (interval < 1) throw new ArgumentException("Harness interval must be greater than zero.");
                if (StartValue < 1) throw new ArgumentException("Harness start value must be greater than zero.");

                List<int> results = new List<int>();
                int value = StartValue;
                results.Add(value);
                while (value < max)
                {
                    value += interval;
                    results.Add(value);
                }
                return results.ToArray();
            }
        }
    }
}
