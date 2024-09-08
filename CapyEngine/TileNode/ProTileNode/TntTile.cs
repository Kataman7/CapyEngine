using CapyEngine.TextureNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.TileNode.ProTileNode
{
    public class TntTile: Tile
    {
        private ObjectID tileId;
        private int x;
        private int y;
        private TileMap tileMap;
        private bool onFire;

        public TntTile(ObjectID tileId, int x, int y, TileMap tileMap) : base(tileId, x, y, tileMap.tileSize)
        {
            this.tileId = tileId;
            this.x = x;
            this.y = y;
            this.tileMap = tileMap;
        }

        private bool TouchFire()
        {
            return tileMap.GetTilePro(x, y - 1).id == ObjectID.FIRE ||
                   tileMap.GetTilePro(x, y + 1).id == ObjectID.FIRE ||
                   tileMap.GetTilePro(x + 1, y).id == ObjectID.FIRE ||
                   tileMap.GetTilePro(x + 1, y).id == ObjectID.FIRE;
        }

        public override void Update()
        {
            if (TouchFire())
            {
                onFire = true;
                texture = TexturesFactory.Get(ObjectID.TNT);
            }
        }
    }
}
