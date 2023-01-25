using MineSweeperGame.Object;
using System;
using System.Windows.Forms;

namespace MineSweeperGame
{
    internal class ButtonsManagment
    {
        private Buttons buttons;
        private Random random = new Random();
        private Form form;
        private int[,] bombsLoc;
        private int row,col,mineCount;
        public ButtonsManagment(Form minesForm,int row,int col)
        {
            this.row = row;
            this.col = col;
            mineCount = row * col / 4;

            form = minesForm;
        }
        public void placeTheButtons()
        {
            int[,] bombs = createBombLocation();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    buttons = new Buttons();
                    buttons.Top = i * buttons.Height;
                    buttons.Left = j * buttons.Width;
                    buttons.isBomb = false;
                    buttons.Text = i + "/" + j;
                    buttons.Click += new EventHandler(this.clickButtons);
                    form.Controls.Add(buttons);
                }
            }
        }
        private int[,] createBombLocation()
        {
            bombsLoc = new int[row, col];
            int c = 0;
            
            while(c<mineCount)
            {
                int bombRow = random.Next(row);
                int bombCol = random.Next(col);
                Console.WriteLine(bombRow + " -- " + bombCol);
                if (bombsLoc[bombRow, bombCol] != -1)
                {
                    c++;
                    bombsLoc[bombRow, bombCol] = -1;
                }
                else
                {
                }
                
            }
            return bombsLoc;
        }
        private void clickButtons(object sender, EventArgs e)
        {
            Buttons btn = sender as Buttons;
            btn.Text = " ";

        }
    }
}
