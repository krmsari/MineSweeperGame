using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGame.Object
{
    internal class MPanel : Panel
    {
        public MPanel() 
        {
            this.Top = 40;
            this.Left = 40;
            this.AutoSize = true;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BorderStyle = BorderStyle.None;
            this.TabStop = false;
        }
    }
}
