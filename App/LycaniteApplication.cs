﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Forms;
using System.IO;
using System.Diagnostics;

namespace App
{
    public partial class LycaniteApplication : MetroSetForm
    {
        public LycaniteApplication()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroSetTabControl1.Padding = new Point(20, 4);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            String name = "";
            TabTemplate newTab = new TabTemplate();
            
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    name = Path.GetFileName(file);

                    newTab.addPath(file);
                }
            }
            TabPage tab = new TabPage();
            tab.Controls.Add(newTab);
            newTab.Dock = DockStyle.Fill;
            tab.Text = name;
    
            metroSetTabControl1.Controls.Add(tab);

            metroSetLabel1.Visible = false;
            metroSetTabControl1.Visible = true;
        }
    }
}