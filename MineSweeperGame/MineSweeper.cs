﻿using MineSweeperGame.FormProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGame
{
    public partial class MineSweeper : Form
    {
        public MineSweeper()
        {
            InitializeComponent();
            
        }

        private void MineSweeper_Load(object sender, EventArgs e)
        {
            MineSweeperFormDesign formProperties = new MineSweeperFormDesign(this,9,9);
            formProperties.run();

            
        }
    }
}
