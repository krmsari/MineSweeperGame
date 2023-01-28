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

        //row locations;
        public int x { get; set; }
        
        // column locations
        public int y { get; set; }

        public Buttons()
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new Font(Font.FontFamily, 10);
            this.FlatStyle = FlatStyle.Popup;
            this.FlatAppearance.BorderSize= 1;
            this.Width = 40;
            this.Height = 40;   
            this.UseVisualStyleBackColor = true;

        }

    }
}
