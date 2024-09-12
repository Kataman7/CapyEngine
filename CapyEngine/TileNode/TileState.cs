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
                { ObjectID.MINERAL_BLACK, TileState.SOLID },
                { ObjectID.MINERAL_PINK, TileState.SOLID },
                { ObjectID.MINERAL_PURPLE, TileState.SOLID },
                { ObjectID.MINERAL_WHITE, TileState.SOLID },
                { ObjectID.STONE_DIRT, TileState.SOLID },
                { ObjectID.STONE_GRASS, TileState.SOLID },
                { ObjectID.GRASS, TileState.VOID },
                { ObjectID.FIRE, TileState.VOID },
                { ObjectID.TNT, TileState.SOLID },
                { ObjectID.TNT_ONFIRE, TileState.SOLID },
                { ObjectID.FLOWER_BLUE, TileState.VOID },
                { ObjectID.FLOWER_RED, TileState.VOID },
                { ObjectID.FLOWER_WHITE, TileState.VOID },
                { ObjectID.FLOWER_PURPLE, TileState.VOID },
                { ObjectID.FLOWER_PINK, TileState.VOID }
            };
        }

        public static TileState Get(ObjectID tileID)
        {
            return list[tileID];
        }
    }
}
