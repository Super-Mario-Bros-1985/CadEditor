﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CadEditor
{
    public partial class EditColor : Form
    {
        public EditColor()
        {
            InitializeComponent();
        }

        private void EditColor_Load(object sender, EventArgs e)
        {
            ColorIndex = -1;
            setColors();
        }

        private void setColors()
        {
            var colors = new Bitmap(256, 256);
            using (Graphics g = Graphics.FromImage(colors))
            {
                for (int i = 0; i < ConfigScript.videoNes.NesColors.Length; i++)
                {
                    g.FillRectangle(new SolidBrush(ConfigScript.videoNes.NesColors[i]), i % 8 * 32, (i / 8) * 32, 32, 32);
                    if (ShowNo)
                        g.DrawString(String.Format("{0:X2}",i), new Font("Arial", 6), Brushes.White, new Rectangle(i % 8 * 32, (i / 8) * 32, 32, 32));
                }
            }
            pbColors.Image = colors;
        }

        private void pbColors_MouseClick(object sender, MouseEventArgs e)
        {
            int index = e.X / 32 + (e.Y / 32) * 8;
            ColorIndex = index;
            Close();
        }

        public static int ColorIndex;
        public bool ShowNo;
    }
}
