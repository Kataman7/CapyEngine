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
                case ObjectID.TNT:
                    return new TntTile(tileId, x, y, tileMap);
                case ObjectID.FLOWER_BLUE:
                    return new DecorationTile(tileId, x, y, tileMap);
                case ObjectID.FLOWER_PINK:
                    return new DecorationTile(tileId, x, y, tileMap);
                case ObjectID.FLOWER_RED:
                    return new DecorationTile(tileId, x, y, tileMap);
                case ObjectID.FLOWER_WHITE:
                    return new DecorationTile(tileId, x, y, tileMap);
                case ObjectID.FLOWER_PURPLE:
                    return new DecorationTile(tileId, x, y, tileMap);
                case ObjectID.GRASS:
                    return new DecorationTile(tileId, x, y, tileMap);
                default:
                    return new Tile(tileId, x, y, tileMap.tileSize); 
            }
        }
    }
}
