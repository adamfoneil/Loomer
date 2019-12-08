﻿namespace Loomer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHarnessOrder = new System.Windows.Forms.TextBox();
            this.chkDrawCoordinates = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSquareSize = new System.Windows.Forms.NumericUpDown();
            this.btnDraw2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvHarnesses = new System.Windows.Forms.DataGridView();
            this.colLetter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cbWeftColor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbWarpColor = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSquareSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHarnesses)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tbHarnessOrder);
            this.splitContainer1.Panel1.Controls.Add(this.chkDrawCoordinates);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.nudSquareSize);
            this.splitContainer1.Panel1.Controls.Add(this.btnDraw2);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.dgvHarnesses);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.cbWeftColor);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cbWarpColor);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Size = new System.Drawing.Size(800, 497);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Harness Order:";
            // 
            // tbHarnessOrder
            // 
            this.tbHarnessOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbHarnessOrder.Location = new System.Drawing.Point(12, 382);
            this.tbHarnessOrder.Name = "tbHarnessOrder";
            this.tbHarnessOrder.Size = new System.Drawing.Size(179, 20);
            this.tbHarnessOrder.TabIndex = 11;
            // 
            // chkDrawCoordinates
            // 
            this.chkDrawCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDrawCoordinates.AutoSize = true;
            this.chkDrawCoordinates.Location = new System.Drawing.Point(12, 410);
            this.chkDrawCoordinates.Name = "chkDrawCoordinates";
            this.chkDrawCoordinates.Size = new System.Drawing.Size(109, 17);
            this.chkDrawCoordinates.TabIndex = 8;
            this.chkDrawCoordinates.Text = "Draw coordinates";
            this.chkDrawCoordinates.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Square Size:";
            // 
            // nudSquareSize
            // 
            this.nudSquareSize.Location = new System.Drawing.Point(87, 106);
            this.nudSquareSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSquareSize.Name = "nudSquareSize";
            this.nudSquareSize.Size = new System.Drawing.Size(104, 20);
            this.nudSquareSize.TabIndex = 5;
            this.nudSquareSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnDraw2
            // 
            this.btnDraw2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDraw2.Location = new System.Drawing.Point(12, 433);
            this.btnDraw2.Name = "btnDraw2";
            this.btnDraw2.Size = new System.Drawing.Size(179, 23);
            this.btnDraw2.TabIndex = 9;
            this.btnDraw2.Text = "Draw";
            this.btnDraw2.UseVisualStyleBackColor = true;
            this.btnDraw2.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Harnesses:";
            // 
            // dgvHarnesses
            // 
            this.dgvHarnesses.AllowUserToResizeColumns = false;
            this.dgvHarnesses.AllowUserToResizeRows = false;
            this.dgvHarnesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvHarnesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHarnesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLetter,
            this.colStart,
            this.colInterval});
            this.dgvHarnesses.Location = new System.Drawing.Point(12, 150);
            this.dgvHarnesses.Name = "dgvHarnesses";
            this.dgvHarnesses.Size = new System.Drawing.Size(179, 207);
            this.dgvHarnesses.TabIndex = 7;
            this.dgvHarnesses.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPatternRules_DefaultValuesNeeded);
            // 
            // colLetter
            // 
            this.colLetter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLetter.DataPropertyName = "Letter";
            this.colLetter.HeaderText = "Harness";
            this.colLetter.MaxInputLength = 1;
            this.colLetter.Name = "colLetter";
            // 
            // colStart
            // 
            this.colStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStart.DataPropertyName = "StartValue";
            this.colStart.HeaderText = "Start";
            this.colStart.Name = "colStart";
            // 
            // colInterval
            // 
            this.colInterval.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInterval.DataPropertyName = "Interval";
            this.colInterval.HeaderText = "Interval";
            this.colInterval.Name = "colInterval";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Weft Color:";
            // 
            // cbWeftColor
            // 
            this.cbWeftColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeftColor.FormattingEnabled = true;
            this.cbWeftColor.Location = new System.Drawing.Point(12, 74);
            this.cbWeftColor.Name = "cbWeftColor";
            this.cbWeftColor.Size = new System.Drawing.Size(179, 21);
            this.cbWeftColor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Warp Color:";
            // 
            // cbWarpColor
            // 
            this.cbWarpColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWarpColor.FormattingEnabled = true;
            this.cbWarpColor.Location = new System.Drawing.Point(12, 27);
            this.cbWarpColor.Name = "cbWarpColor";
            this.cbWarpColor.Size = new System.Drawing.Size(179, 21);
            this.cbWarpColor.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(12, 462);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(179, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSquareSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHarnesses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbWeftColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbWarpColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvHarnesses;
        private System.Windows.Forms.Button btnDraw2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSquareSize;
        private System.Windows.Forms.CheckBox chkDrawCoordinates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHarnessOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLetter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterval;
    }
}
