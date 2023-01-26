using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGame.Object
{
    internal class Buttons : Button
    {
        public bool isBomb { get; set; }

        // This attributes specifies the x and y coordinates of the Button
        public int x { get; set; }
        //private int[] x;
        
        public int y { get; set; }
        public Buttons()
        {
            this.isBomb= false;
            this.Width = 40;
            this.Height = 40;
            this.UseVisualStyleBackColor = true;

        }
        
    }
}
