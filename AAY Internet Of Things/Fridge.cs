﻿using AAY_Internet_Of_Things.FridgeApps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAY_Internet_Of_Things
{
    public partial class Fridge : Form
    {
        private bool active = false;
        private Stack<string> history = new Stack<string>();
        private Dictionary<string,Control> apps = new Dictionary<string, Control>();
        public Fridge()
        {
            InitializeComponent();
        }

        //on/off koumpi
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            active = !active;
            if (active) pictureBox5_Click(null, null); //home koumpi
            else { panel1.Controls.Clear(); history.Clear(); apps.Clear(); }
            pictureBox3.Enabled = pictureBox4.Enabled = pictureBox5.Enabled = active;
        }

        //back koumpi
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (history.Count >= 2){
                panel1.Controls.Clear();
                history.Pop();
                panel1.Controls.Add(apps[history.Peek()]);
            }
            else
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(apps["home"]);
            }
        }

        //menu koumpi
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(!apps.ContainsKey("menu"))
                apps.Add("menu",new FridgeApps.Menu(icon_DoubleClick));
            history.Push("menu");
            panel1.Controls.Clear();
            panel1.Controls.Add(apps["menu"]);
        }

        //home koumpi
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(!apps.ContainsKey("home"))
                apps.Add("home", new FridgeApps.Home(pictureBox4_Click));
            history.Push("home");
            panel1.Controls.Clear();
            panel1.Controls.Add(apps["home"]);
        }

        //menu icons
        private void icon_DoubleClick(object sender, EventArgs e)
        {
            Control menuIcon = ((PictureBox)sender).Parent;
            Control target = (Control)menuIcon.Tag;
            String nameKey = menuIcon.Controls[1].Text; //text tou label tou menuicon
            if (!apps.ContainsKey(nameKey))
                apps.Add(nameKey, target);
            history.Push(nameKey);
            panel1.Controls.Clear();
            panel1.Controls.Add(target);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FridgePhoneApp().Show();
        }

        private void Fridge_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Help.ShowHelp(this, "manual.chm", HelpNavigator.TopicId, "40");
        }
    }

}
