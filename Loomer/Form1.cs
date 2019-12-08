using JsonSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinForms.Library.Extensions;

namespace Loomer
{
    public partial class Form1 : Form
    {
        private Options _options = null;

        public Form1()
        {
            InitializeComponent();
        }
      
        private void btnClear_Click(object sender, EventArgs e)
        {
            using (var g = splitContainer1.Panel2.CreateGraphics())
            {
                g.Clear(splitContainer1.Panel2.BackColor);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            FillColorOptions(cbWarpColor);
            FillColorOptions(cbWeftColor);

            _options = LoadOptions();
            cbWarpColor.SetItem(new ColorOption(_options.WarpColor));
            cbWeftColor.SetItem(new ColorOption(_options.WeftColor));
            nudSquareSize.Value = _options.SquareSize;
            chkDrawCoordinates.Checked = _options.DrawCoordinates;
            tbHarnessOrder.Text = _options.HarnessOrder;

            BindingSource bs = new BindingSource();
            var list = new BindingList<SimpleWeaver.Harness>(_options.Patterns ?? new List<SimpleWeaver.Harness>());
            list.AllowNew = true;
            bs.DataSource = list;
            dgvHarnesses.DataSource = bs;
        }

        private string OptionsFilename { get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LoomerSettings.json"); } }

        private Options LoadOptions()
        {
            var result =
                (File.Exists(OptionsFilename)) ? JsonFile.Load<Options>(OptionsFilename) :
                new Options();

            // make sure no zero in square size
            if (result.SquareSize < 1) result.SquareSize = 1;

            return result;
        }

        private void SaveOptions()
        {
            _options.WarpColor = cbWarpColor.GetItem<ColorOption>().Color;
            _options.WeftColor = cbWeftColor.GetItem<ColorOption>().Color;
            _options.SquareSize = Convert.ToInt32(nudSquareSize.Value);
            _options.Patterns = (dgvHarnesses.DataSource as BindingSource).OfType<SimpleWeaver.Harness>().ToList();
            _options.DrawCoordinates = chkDrawCoordinates.Checked;
            _options.HarnessOrder = tbHarnessOrder.Text;
            JsonFile.Save(OptionsFilename, _options);
        }

        private void FillColorOptions(ComboBox comboBox)
        {
            // thanks to https://stackoverflow.com/a/14047729/2023653

            comboBox.Items.Clear();
            comboBox.ValueMember = "Color";
            comboBox.DisplayMember = "Name";

            var colors = typeof(Brushes).GetProperties().Select(pi => pi.Name).ToArray();
            foreach (var item in colors) comboBox.Items.Add(new ColorOption() { Color = Color.FromName(item), Name = item });
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                var weaver = new SimpleWeaver(splitContainer1.Panel2)
                {
                    Font = this.Font,
                    SquareSize = Convert.ToInt32(nudSquareSize.Value),
                    WarpColor = (cbWarpColor.SelectedItem as ColorOption).ToBrush(),
                    WeftColor = (cbWeftColor.SelectedItem as ColorOption).ToBrush(),
                    Harnesses = (dgvHarnesses.DataSource as BindingSource).OfType<SimpleWeaver.Harness>().ToArray(),
                    HarnessOrder = tbHarnessOrder.Text,
                    DrawCoordinates = chkDrawCoordinates.Checked
                };

                weaver.AlertUnusedHarnesses(dgvHarnesses);

                weaver.Draw();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveOptions();
        }

        private void dgvPatternRules_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["colLetter"].Value = SimpleWeaver.HarnessLetters[e.Row.Index];
        }
    }
}
