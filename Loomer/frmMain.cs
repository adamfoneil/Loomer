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
using WinForms.Library.Models;

namespace Loomer
{
    public partial class frmMain : Form
    {
        private Options _options = null;

        public frmMain()
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
            try
            {
                FillColorOptions(cbWarpColor);
                FillColorOptions(cbWeftColor);

                _options = LoadOptions();
                _options.FormPosition?.Apply(this);

                if (_options.Weaver != null) LoadWeaverOptions(_options.Weaver);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void LoadWeaverOptions(SimpleWeaver weaver)
        {
            cbWarpColor.SetItem(new ColorOption(weaver.WarpColor));
            cbWeftColor.SetItem(new ColorOption(weaver.WeftColor));
            nudSquareSize.Value = weaver.SquareSize;
            chkDrawCoordinates.Checked = weaver.DrawCoordinates;
            tbHarnessOrder.Text = weaver.HarnessOrder;

            BindingSource bs = new BindingSource();
            var list = new BindingList<SimpleWeaver.Harness>(weaver?.Harnesses ?? new List<SimpleWeaver.Harness>());
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

            if (result.Weaver == null) result.Weaver = new SimpleWeaver();

            // make sure no zero in square size
            if (result.Weaver?.SquareSize < 5) result.Weaver.SquareSize = 5;

            return result;
        }

        private void SaveOptions()
        {
            _options.Weaver = new SimpleWeaver();
            _options.Weaver.WarpColor = cbWarpColor.GetItem<ColorOption>().Color;
            _options.Weaver.WeftColor = cbWeftColor.GetItem<ColorOption>().Color;
            _options.Weaver.SquareSize = Convert.ToInt32(nudSquareSize.Value);
            _options.Weaver.Harnesses = (dgvHarnesses.DataSource as BindingSource).OfType<SimpleWeaver.Harness>().ToList();
            _options.Weaver.DrawCoordinates = chkDrawCoordinates.Checked;
            _options.Weaver.HarnessOrder = tbHarnessOrder.Text;
            _options.FormPosition = FormPosition.FromForm(this);
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
                SimpleWeaver weaver = GetWeaver();
                weaver.AlertUnusedHarnesses(dgvHarnesses);
                weaver.Draw(splitContainer1.Panel2);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }

        private SimpleWeaver GetWeaver()
        {
            return new SimpleWeaver()
            {
                Font = this.Font,
                SquareSize = Convert.ToInt32(nudSquareSize.Value),
                WarpColor = (cbWarpColor.SelectedItem as ColorOption).Color,
                WeftColor = (cbWeftColor.SelectedItem as ColorOption).Color,
                Harnesses = (dgvHarnesses.DataSource as BindingSource).OfType<SimpleWeaver.Harness>().ToList(),
                HarnessOrder = tbHarnessOrder.Text,
                DrawCoordinates = chkDrawCoordinates.Checked
            };
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveOptions();
        }

        private void dgvPatternRules_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["colLetter"].Value = SimpleWeaver.HarnessLetters[e.Row.Index];
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new SaveFileDialog();
                dlg.Filter = "Json Files|*.json|All Files|*.*";
                dlg.DefaultExt = "json";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var weaver = GetWeaver();
                    JsonFile.Save(dlg.FileName, weaver);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                dlg.Filter = "Json Files|*.json|All Files|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var weaver = JsonFile.Load<SimpleWeaver>(dlg.FileName);
                    LoadWeaverOptions(weaver);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
