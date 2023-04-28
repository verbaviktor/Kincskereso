using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Kincskereso
{
    internal class Resources
    {
        public Dictionary<TileType, int> resources;

        public Resources()
        {
            resources = new Dictionary<TileType, int> {
                {TileType.Erdo, 3 },
                {TileType.Hegy, 3 },
                {TileType.Domb, 3 },
                {TileType.Ret, 0 },
                {TileType.Sarok, 0 },
            };
        }

        public bool Add_resource(TileType type) {

            resources[type] += 1;
            
            return true;
        }

        public bool Remove_resource(TileType type) {

            resources[type] -= 1;

            return true;
        }
    }
}
