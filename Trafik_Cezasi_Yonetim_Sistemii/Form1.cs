﻿using System;
using System.Windows.Forms;

namespace Trafik_Cezasi_Yonetim_Sistemii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            polisPanel polisPanelForm = new polisPanel(this);
            polisPanelForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cezaSorgulamaForm sorgulamaForm = new cezaSorgulamaForm(this);
            sorgulamaForm.Show();
            this.Hide();
        }
    }
}
