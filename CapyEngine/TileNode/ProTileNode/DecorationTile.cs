using CapyEngine.UtilsNode;

namespace CapyEngine.TileNode.ProTileNode
{
    public class DecorationTile: Tile
    {
        private TileMap tileMap;
        private int x;
        private int y;

        public DecorationTile(ObjectID id, int x, int y, TileMap tileMap) : base(id, x, y, tileMap.tileSize)
        {
            this.tileMap = tileMap;
            this.x = x;
            this.y = y;
        }

        public override void Update()
        {
            if (GameManager.currentWorld != null)
            {
                if (tileMap.GetTilePro(x, y + 1).id != ObjectID.DIRT && tileMap.GetTilePro(x, y + 1).id != ObjectID.DIRT_GRASS)
                {
                    Destroy(GameManager.currentWorld);
                }
            }
        }
    }
}
