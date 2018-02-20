﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAY_Internet_Of_Things.FridgeApps
{
    public partial class Home : UserControl
    {
        public Home(MouseEventHandler wallpaperClick)
        {
            InitializeComponent();
            this.MouseClick += wallpaperClick;
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
