using MineSweeperGame.Object;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace MineSweeperGame
{
    internal class ButtonsManagment
    {
        private Buttons button;
        private Form form;
        private Random random = new Random();
        private int row, col, mineCount, enabledButton=0;
        private MPanel panel;
        private Label scoreLabel;
        private Buttons[,] buttons;
        public bool gameOver;
        public int score;
        private int[,] mines, bombsLoc;

        public ButtonsManagment(Form minesForm, int row, int col,int mineCount)
        {

            panel = new MPanel();
            scoreLabel = new Label();
            this.row = row;
            this.col = col;
            this.mineCount = mineCount;
            mines = new int[mineCount, 2];
            gameOver = true;
            form = minesForm;
        }
        public void placeTheButtons()
        {
            panel.Controls.Clear();
            score = 0;
            enabledButton = 0;
            createBombLocation(mineCount, row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {

                    button = new Buttons();
                    button.Top = i * button.Height;
                    button.Left = j * button.Width;
                    button.x = i;
                    button.y = j;
                    buttons[i, j] = button;
                    //button.Text = i + "-" + j;  
                    button.Click += new EventHandler(this.clickButtons);

                    panel.Controls.Add(button);

                }

            }
            form.Controls.Add(panel);

        }
        private void createBombLocation(int mineCount, int row, int col)
        {
            bombsLoc = new int[row, col];
            buttons = new Buttons[row, col];
            int c = 0;

            while (c < mineCount)
            {

                mines[c, 0] = random.Next(row);
                mines[c, 1] = random.Next(col);

                if (bombsLoc[mines[c, 0], mines[c, 1]] == -1) continue;
                bombsLoc[mines[c, 0], mines[c, 1]] = -1;
                

                Console.WriteLine(c + ". BOMBA:  " + mines[c, 0] + " -- " + mines[c, 1]);

                for (int rowDif = -1; rowDif <= 1; rowDif++)
                {
                    for (int columnDif = -1; columnDif <= 1; columnDif++)
                    {
                        //                                      check if in range -->
                        if (mines[c, 0] + rowDif < 0) continue;
                        if (mines[c, 1] + columnDif < 0) continue;
                        if (mines[c, 0] + rowDif >= row) continue;
                        if (mines[c, 1] + columnDif >= col) continue;
                        //<--


                        //check bomb count in around the selected button -->
                        if (bombsLoc[mines[c, 0] + rowDif, mines[c, 1] + columnDif] != -1)
                        {
                            bombsLoc[mines[c, 0] + rowDif, mines[c, 1] + columnDif]++;
                        }
                        //<--


                        //                                      -- These comments are long version of the above --
                        //if (bombsLoc[bombRow-1,bombCol -1])
                        //{
                        //    bombsLoc[bombRow + -1, bombCol + -1]++
                        //}
                        //if (bombsLoc[bombRow -1,bombCol + 0])
                        //{
                        //    bombsLoc[bombRow + -1, bombCol + 0]++
                        //}
                        //                                                              ...

                    }
                }
                c++;

            }

        }
        private bool win()
        {
            Console.WriteLine((row * col -  enabledButton));
            if ((row * col - enabledButton) == mineCount)
            {
                finish();
                scoreCal(score, "You are win.");
                Console.WriteLine("girdi: " + (row*col-enabledButton));
                return true;
            }
            else
            {
                Console.WriteLine("false");
                return false;   
            }
        }
        private void clickButtons(object sender, EventArgs e)
        {
            if (gameOver)
            {
                Buttons btn = sender as Buttons;
                btn.BackColor = Color.DimGray;
                if (bombsLoc[btn.x, btn.y] == -1)
                {
                    finish();
                    scoreCal(score, "GAME OVER");
                }
                else
                {
                    if (bombsLoc[btn.x, btn.y] == 0)
                    {
                        btn.Text = "";
                        opener(btn.x, btn.y);
                    }
                    else
                    {
                        btn.Text = bombsLoc[btn.x, btn.y].ToString();
                        score += bombsLoc[btn.x, btn.y];
                        Console.WriteLine("score: " + score);
                        scoreCal(score,"");
                        btn.Enabled = false;
                        enabledButton++;

                    }

                }

            }
            win();
        }

        private void opener(int x, int y)
        {
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));
            while (stack.Count > 0)
            {
                //                                      check if in range -->
                Point point = stack.Pop();
                if (point.X < 0 || point.Y < 0) continue;
                if (point.X >= bombsLoc.GetLength(0) || point.Y >= bombsLoc.GetLength(1)) continue;
                //<--


                //                                      check if active -->
                if (!buttons[point.X, point.Y].Enabled) continue;
                //<--

                buttons[point.X, point.Y].Enabled = false;
                enabledButton++;
                buttons[point.X, point.Y].BackColor = Color.DimGray;

                if (bombsLoc[point.X, point.Y] != 0)
                {
                    buttons[point.X, point.Y].Text = bombsLoc[point.X, point.Y].ToString();
                    score += bombsLoc[point.X, point.Y];
                    Console.WriteLine("score: " + score);
                    scoreCal(score, "");
                    Console.WriteLine(point.X + ", " + point.Y + " butonu sınır");

                }


                if (bombsLoc[point.X, point.Y] != 0) continue;

                //UST VE ALT KONTROLU
                stack.Push(new Point(point.X - 1, point.Y));
                stack.Push(new Point(point.X + 1, point.Y));

                //SAG VE SOL KONTROLU
                stack.Push(new Point(point.X, point.Y - 1));
                stack.Push(new Point(point.X, point.Y + 1));

                //KOSELERIN KONTROLU
                stack.Push(new Point(point.X + 1, point.Y + 1));
                stack.Push(new Point(point.X + 1, point.Y - 1));
                stack.Push(new Point(point.X - 1, point.Y - 1));
                stack.Push(new Point(point.X - 1, point.Y + 1));
            }
            //foreach (Point p in stack)
            //{
            //    Console.WriteLine(p.X.ToString() + " " + p.IsEmpty);
            //}

        }
        public void scoreCal(int score,string text)
        {

            scoreLabel.Font = new Font(scoreLabel.Font.FontFamily, 12);
            scoreLabel.Left = form.Width - 230;
            scoreLabel.AutoSize = true;
            scoreLabel.Top = 130;
            scoreLabel.Text = "   Score: " + score.ToString() + "\n"+text;
            panel.Controls.Add(scoreLabel);
        }
        private void finish()
        {
            
            for (int i = 0; i < mineCount; i++)
            {
                buttons[mines[i, 0], mines[i, 1]].Font = new Font(buttons[mines[i, 0], mines[i, 1]].Font.FontFamily, 18);
                buttons[mines[i, 0], mines[i, 1]].Text = "\U0001F4A3";
                buttons[mines[i, 0], mines[i, 1]].BackColor = Color.IndianRed;
                System.Threading.Thread.Sleep(160);
                buttons[mines[i, 0], mines[i, 1]].Enabled = false;
                buttons[mines[i, 0], mines[i, 1]].BackColor = Color.DimGray;

            }
            Console.WriteLine(score);
            gameOver = false;
        }
    }
}
