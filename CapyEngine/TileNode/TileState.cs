using CapyEngine.UtilsNode;
using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapyEngine.TileNode
{
    public enum TileState
    {
        VOID, SOLID, LIQUID, STAIR
    }

    public static class TileStates
    {
        private static Dictionary<ObjectID, TileState> list;

        static TileStates()
        {
            list = new Dictionary<ObjectID, TileState>()
            {
                { ObjectID.VOID, TileState.VOID },
                { ObjectID.DIRT, TileState.SOLID },
                { ObjectID.DIRT_GRASS, TileState.SOLID },
                { ObjectID.STONE, TileState.SOLID },
                { ObjectID.VINE, TileState.STAIR },
            };
        }

        public static TileState Get(ObjectID tileID)
        {
            return list[tileID];
        }
    }
}
