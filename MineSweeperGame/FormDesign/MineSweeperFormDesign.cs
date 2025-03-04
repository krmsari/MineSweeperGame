﻿using MineSweeperGame.Object;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MineSweeperGame.FormProperties
{
    internal class MineSweeperFormDesign : Form
    {
        private Form form;
        private Buttons startButton, closeButton;
        private Label bombCount, bombText;
        ButtonsManagment buttonsManagment;
        private int row, col,mineCount;
        public MineSweeperFormDesign(Form form, int row, int col)
        {
            this.form = form;
            this.row = row;
            this.col = col;
            mineCount = row * col / 8;
            buttonsManagment = new ButtonsManagment(form, row, col,mineCount);

        }
        public void run()
        {
            formProperties();
            managmentButtons();
        }
        private void formProperties()
        {
            Rectangle screen = Screen.FromControl(this).Bounds;
            form.Text = "Mine Sweeper";
            form.Location = new Point(50,screen.Height/5);
            form.BackColor = Color.Gray;
            form.MinimumSize = new System.Drawing.Size(800, 600);
            form.MaximumSize = new System.Drawing.Size(900,700);
            form.Icon = new Icon(@"D:\OneDrive\Kerem\Repository\CSharp\MineSweeperGame\MineSweeperGame\Image\bomb.ico");

        }

        // This method manage the close, restart and start buttons.
        private void managmentButtons()
        {
            startButton = new Buttons();
            closeButton = new Buttons();

            startButton.Text = "Start";
            startButton.Height = 40;
            startButton.Width = 80;
            startButton.Font = new Font(startButton.Font.FontFamily, 12);
            startButton.Left = form.Width - 120;
            startButton.Top = 30;
            startButton.Click += new EventHandler(this.clickStartButton);
            form.Controls.Add(startButton);

            closeButton.Height = 40;
            closeButton.Text = "Cancel";
            closeButton.Width = 80;
            closeButton.Font = new Font(closeButton.Font.FontFamily, 12);
            closeButton.Left = form.Width - 120;
            closeButton.Top = 80;
            closeButton.Click += new EventHandler(this.clickCancelButton);
            form.Controls.Add(closeButton);

        }

        private void displayLabels()
        {
            bombCount = new Label();
            bombText = new Label();
            bombCount.Font = new Font(bombCount.Font.FontFamily, 14);
            bombCount.ForeColor = Color.Red;
            bombCount.Width = 30;
            bombCount.Left = form.Width - 200;
            bombCount.Top = 55;
            bombCount.Text = mineCount.ToString();

            bombText.Font = new Font(bombText.Font.FontFamily, 11);
            bombText.Left = form.Width - 230;
            bombText.Top = 40;
            bombText.Text = "Bomb Count: ";
            form.Controls.Add(bombCount);
            form.Controls.Add(bombText);
        }



        protected void clickStartButton(object sender, EventArgs e)
        {
            Buttons button = sender as Buttons;
            //mine = 0;
            //fieldCount = 25;
            //minesCount = fieldCount / 4;
            displayLabels();
            managmentButtons();
            buttonsManagment.scoreCal(0,"");
            buttonsManagment.gameOver = true;
            buttonsManagment.placeTheButtons();

            button.Text = "Restart";
        }
        protected void clickCancelButton(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close this game ?", "Do you sure ?", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result) form.Close();

        }

    }
}
