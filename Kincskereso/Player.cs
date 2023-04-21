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
        public Tool  Utcount{ get; set; }
        public Tool Asocount { get; set; }
        public bool[5] traversed { get; set; }
        public int Kincsekcsount { get; set; }
        public int Lepescount{ get; set; }


    }
}
