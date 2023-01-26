using MineSweeperGame.Object;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeperGame
{
    internal class ButtonsManagment
    {
        private Buttons button;
        private Form form;
        private Random random = new Random();
        private int row, col, mineCount;
        private Panel panel;
        List<Buttons> buttons;
        int[,] bombsLoc;
        public ButtonsManagment(Form minesForm, int row, int col)
        {
            panel = new Panel();
            this.row = row;
            this.col = col;
            mineCount = row * col / 4;
            form = minesForm;
        }
        public void placeTheButtons()
        {

            panel.Controls.Clear();
            createBombLocation(mineCount, row, col);
            panel.AutoSize = true;
            buttons = new List<Buttons>();
            //while (true)
            //{
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {

                    button = new Buttons();
                    button.Top = i * button.Height;
                    button.Left = j * button.Width;
                    button.x = i;
                    button.y = j;
                    button.Text = i + "/" + j;
                    button.Click += new EventHandler(this.clickButtons);
                    buttons.Add(button);
                    panel.Controls.Add(button);


                }

            }
            form.Controls.Add(panel);
            //}

        }
        private void createBombLocation(int mineCount, int row, int col)
        {
            bombsLoc = new int[row, col];


            while (mineCount > 0)
            {
                int bombRow = random.Next(row);
                int bombCol = random.Next(col);

                if (bombsLoc[bombRow, bombCol] == -1) continue;
                bombsLoc[bombRow, bombCol] = -1;
                Console.WriteLine("BOMBA:  " + bombRow + " -- " + bombCol);

                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (bombRow + dx < 0) continue;
                        if (bombCol + dy < 0) continue;
                        if (bombRow + dx >= row) continue;
                        if (bombCol + dy >= col) continue;

                        if (bombsLoc[bombRow + dx, bombCol + dy] != -1)
                        {
                            bombsLoc[bombRow + dx, bombCol + dy]++;
                        }
                    }
                }
                mineCount--;

            }

        }
        private void clickButtons(object sender, EventArgs e)
        {
            Buttons btn = sender as Buttons;
            if (bombsLoc[btn.x, btn.y] == -1)
            {
                btn.Text = "\U0001F4A3";
                btn.isBomb = true;
                btn.Font = new Font(btn.Font.FontFamily, 18);
                //buttons.ForEach(b =>
                //{
                //    b.Enabled = false;
                //});
                btn.ForeColor = Color.Black;
                Console.WriteLine("girdi"); 
            }
            else
            {
                if (bombsLoc[btn.x, btn.y ] == 0)
                {
                    btn.Text = "";
                }
                else
                {
                    btn.Text = "" + bombsLoc[btn.x, btn.y];
                }

            }


            btn.Enabled = false;
            Console.WriteLine(btn.x + " -- " + btn.y);

        }
    }
}
