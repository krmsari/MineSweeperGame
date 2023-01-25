using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGame.FormProperties
{
    internal class MineSweeperFormProperties : Form
    {
        private Form form;
        private Button startButton, closeButton;
        private Label bombCount, bombText;

        public MineSweeperFormProperties(Form minesForm)
        {
            form = minesForm;
        }

        public void formProperties()
        {
            form.Text = "Mine Sweeper";
            form.BackColor = Color.Gray;
            form.MaximumSize = new System.Drawing.Size(500,550);
            form.MinimumSize= new System.Drawing.Size(500, 550);
            form.Icon = new Icon("D:\\Kerem\\Repository\\CSharp\\MineSweeperGame\\MineSweeperGame\\Image\\bomb.ico");
            form.HelpButton = true;
            form.Menu = new System.Windows.Forms.MainMenu();
            managmentButtons();
            displayLabels();
        }
        // This method manage the close, restart and start buttons.
        public void managmentButtons()
        {
            startButton = new Button();
            closeButton = new Button();
            
            startButton.Text = "Start";
            startButton.Height = 40;
            startButton.Width = 80;
            startButton.Font = new Font(startButton.Font.FontFamily, 12);
            startButton.Left = form.Width - 120;
            startButton.Top = 30;
            startButton.UseVisualStyleBackColor = true;
            //startButton.Click += new EventHandler(this.clickStartButton);
            form.Controls.Add(startButton);

            closeButton.Height = 40;
            closeButton.Text = "Cancel";
            closeButton.Width = 80;
            closeButton.Font = new Font(closeButton.Font.FontFamily, 12);
            closeButton.Left = form.Width - 120;
            closeButton.Top = 80;
            closeButton.UseVisualStyleBackColor = true;
            //closeButton.Click += new EventHandler(this.clickCancelButton);
            form.Controls.Add(closeButton);

        }

        public void displayLabels()
        {
            bombCount = new Label();
            bombText = new Label();
            bombCount.Font = new Font(bombCount.Font.FontFamily, 12);
            bombCount.ForeColor = Color.Red;
            bombCount.Left = form.Width - 180;
            bombCount.Top = 55;
            //bombCount.Text = minesCount.ToString();

            bombText.Font = new Font(bombText.Font.FontFamily, 9);
            bombText.Left = form.Width - 210;
            bombText.Top = 40;
            bombText.Text = "Bomb Count:";
            form.Controls.Add(bombCount);
            form.Controls.Add(bombText);
        }

    }
}
