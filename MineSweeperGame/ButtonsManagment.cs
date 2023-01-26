using MineSweeperGame.Object;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeperGame
{
    internal class ButtonsManagment
    {
        private Buttons buttons;
        private Form form;
        private Random random = new Random();
        private int row, col, mineCount;
        private bool gameOver;
        int[,] bombsLoc;
        public ButtonsManagment(Form minesForm, int row, int col)
        {

            this.row = row;
            this.col = col;
            mineCount = row * col / 4;
            form = minesForm;
        }
        public void placeTheButtons()
        {

            createBombLocation(mineCount, row, col);
            //while (true)
            //{
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {

                    buttons = new Buttons();
                    buttons.Top = i * buttons.Height;
                    buttons.Left = j * buttons.Width;
                    buttons.x = i;
                    buttons.y = j;
                    buttons.Text = i + "/" + j;
                    buttons.Click += new EventHandler(this.clickButtons);
                    form.Controls.Add(buttons);


                }

            }
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
