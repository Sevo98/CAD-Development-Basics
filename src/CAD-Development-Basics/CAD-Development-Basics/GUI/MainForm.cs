﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAD_Development_Basics
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOpenDrawing_Click(object sender, EventArgs e)
        {
            Drawing drawing = new Drawing();
            drawing.Show();
        }


        private void buttonBuild_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите построить модель с данными значениями?", "Внимание!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //....
            }
            else if (dialogResult == DialogResult.No)
            {
                //...
            }
        }
    }
}
