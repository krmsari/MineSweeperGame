using MineSweeperGame.Object;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeperGame
{
    internal class ButtonsManagment
    {
        private Buttons buttons;
        private Random random = new Random();
        private Form form;
        private int[,] bombsLoc;
        private int row, col, mineCount;
        public ButtonsManagment(Form minesForm, int row, int col)
        {
            this.row = row;
            this.col = col;
            mineCount = row * col / 4;

            form = minesForm;
        }
        public void placeTheButtons()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    buttons = new Buttons();
                    buttons.Top = i * buttons.Height;
                    buttons.Left = j * buttons.Width;
                    //createBombLocation(buttons);
                    buttons.x = i;
                    buttons.y = j;
                    buttons.Text = i + "/" + j;
                    buttons.Click += new EventHandler(this.clickButtons);
                    form.Controls.Add(buttons);
                }
            }
        }
        private void createBombLocation()
        {
            bombsLoc = new int[row, col];

            while (mineCount>0)
            {
                int bombRow = random.Next(row);
                int bombCol = random.Next(col);
                Console.WriteLine("BOMBA:  " + bombRow + " -- " + bombCol);
                if (bombsLoc[bombRow, bombCol] == -1)
                {
                    continue;
                }
                else
                {
                    bombsLoc[bombRow, bombCol] = -1;
                }
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (bombRow + dx < 0) continue;
                        if (bombCol + dy < 0) continue;
                        if (bombRow + dx >= row) continue;
                        if (bombCol + dy >= col) continue;

                        if (bombsLoc[bombRow+dx, bombCol+dy] != -1) { }
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
            createBombLocation();

            if (bombsLoc[btn.x,btn.y] == -1)
            {
                btn.Text = "\U0001F4A3";
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.ForeColor = Color.Black;
                btn.BackColor = Color.Black;
                Console.WriteLine(  "girdi");
            }
            


            Console.WriteLine(btn.x + " -- " + btn.y);
            btn.Text = " ";

        }
    }
}
