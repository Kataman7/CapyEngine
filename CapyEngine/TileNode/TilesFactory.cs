using CapyEngine.TileNode.ProTileNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.TileNode
{
    public static class TilesFactory
    {
        public static Tile Create(ObjectID tileId, TileMap tileMap, int x, int y)
        {
            switch (tileId)
            {
                case ObjectID.VINE:
                    return new VineTile(tileId, x, y, tileMap);
                default:
                    return new Tile(tileId, x, y, tileMap.tileSize); 
            }
        }
    }
}
