using CapyEngine.Exemple.Dune;
using CapyEngine.TextureNode;
using CapyEngine.UtilsNode;
using CapyEngine.WorldNode;
using Raylib_CsLo;
using System.Transactions;

namespace CapyEngine.TileNode.ProTileNode
{
    public class VineTile: Tile
    {
        private UtilNode.Timer timer;
        private TileMap tileMap;
        private int x;
        private int y;
        public bool updated;
        

        public VineTile(ObjectID id, int x, int y, TileMap tileMap) : base(id, x, y, tileMap.tileSize)
        {
            this.tileMap = tileMap;
            this.x = x;
            this.y = y;
            this.timer = new(2f);
            updated = true;
        }

        public override void Update()
        {
            if (timer.IsTimeUp())
            {
                if (!updated)
                {
                    if (tileMap.GetTilePro(x, y - 1).state != TileState.SOLID && tileMap.GetTilePro(x, y - 1).state != TileState.STAIR)
                    {
                        if (GameManager.currentWorld != null)
                        {
                            tileMap.SetTile(x, y, ObjectID.VOID);
                            updated = true;
                            GameManager.currentWorld.entities.Add(new Drop((int)(hitBox.X + hitBox.width / 4), (int)(hitBox.y + hitBox.width / 4), this, GameManager.currentWorld));
                        }
                    }
                    else if (tileMap.GetTilePro(x, y + 1).state == TileState.VOID)
                    {
                        tileMap.SetTilePro(x, y + 1, ObjectID.VINE);
                    }
                }
                else
                {
                    updated = false;
                }
            }
        }
    }
}
