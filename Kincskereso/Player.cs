﻿using System;
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
        public int Kincsekcsount { get; set; }
        public int Lepescount{ get; set; }

        public Player()
        {
            traversed = new bool[5];
        }
    }
}