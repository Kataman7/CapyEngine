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
        VOID, SOLID, LIQUID
    }

    public static class TileStates
    {
        private static Dictionary<TileID, TileState> list;

        static TileStates()
        {
           list = new Dictionary<TileID, TileState>()
           {
                { TileID.VOID, TileState.VOID },
                { TileID.DIRT, TileState.SOLID },
                { TileID.DIRT_GRASS, TileState.SOLID },
                { TileID.STONE, TileState.SOLID }
           };
        }

        public static TileState Get(TileID tileID)
        {
            return list[tileID];
        }
    }
}
