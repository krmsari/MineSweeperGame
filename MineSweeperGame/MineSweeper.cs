using MineSweeperGame.FormProperties;
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
        private int i, j;

        public MineSweeper()
        {
            InitializeComponent();
            MineSweeperFormProperties formProperties = new MineSweeperFormProperties(this);
            formProperties.formProperties();
            ButtonsManagment buttons = new ButtonsManagment(this,5,5);
            //for (i = 0; i < 30; i++)
            //{
                //for (j = 0; j < 30; j++)
                //{
                    buttons.placeTheButtons();
                //}
            //}
        }

        private void MineSweeper_Load(object sender, EventArgs e)
        {

        }
    }
}
