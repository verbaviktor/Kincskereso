using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kincskereso
{
    public class Tile
    {
        public TileType Type;
        public bool[] Direction = new bool[4];

        public Tile(TileType type)
        {
            Type = type;
        }

        public Tile(int type)
        {
            Type = (TileType)type;
        }
    }
}
