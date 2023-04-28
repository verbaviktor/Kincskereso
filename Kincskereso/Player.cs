using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kincskereso
{
    internal class Player
    {
        public Point Position{ get; set; }
        public int Utcount{ get; set; }
        public int Asocount { get; set; }
        public bool[] traversed { get; set; }
        public int Lepescount{ get; set; }

        public Resources anyagok { get; set; }

        public Player(Point pos)
        {
            Position = pos;
            traversed = new bool[5];
            anyagok = new Resources();
        }
    }
}
