
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Kincskereso
{
    internal class Tools
    {
        static public bool CreateAso (Resources anyagok, Player player)
        {
            if (anyagok.resources[TileType.Hegy] <= 1 && anyagok.resources[TileType.Erdő] <= 1)
            {
                player.Asocount += 1;
                anyagok.Remove_resource(TileType.Hegy);
                anyagok.Remove_resource(TileType.Erdő);
                return true;

            }
            
            return false;
        }

        static public bool CreateUt(Resources anyagok, Player player)
        {
            if (anyagok.resources[TileType.Domb] <= 1 && anyagok.resources[TileType.Erdő] <= 1)
            {
                player.Asocount += 1;
                anyagok.Remove_resource(TileType.Domb);
                anyagok.Remove_resource(TileType.Erdő);
                return true;

            }

            return false;
        }
    }
}
