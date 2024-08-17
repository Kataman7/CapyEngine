using CapyEngine.TileNode;
using CapyEngine.WorldNode;
using Raylib_CsLo;

namespace CapyEngine.EntityNode.DynamicEntityNode
{
    public class DynamicEntity : Entity
    {
        protected float velX;
        protected float velY;
        protected int range;
        protected float weight;
        protected World world;
        public bool alive;

        public DynamicEntity(int x, int y, float width, float height, int range, float weight, World world) : base(x, y, width, height, world.tileMap.tileSize)
        {
            velX = 0;
            velY = 0;
            this.range = range;
            this.weight = weight;
            this.world = world;
            alive = true;
        }
        public TileState checkTileMapCollision()
        {
            float blockX = hitBox.x / world.tileMap.tileSize;
            float blockY = hitBox.y / world.tileMap.tileSize;

            for (int y = (int)blockY - 5; y < blockY + 5; ++y)
            {
                for (int x = (int)blockX - 5; x < blockX + 5; ++x)
                {
                    Tile tile = world.tileMap.GetTilePro(x, y);

                    if (Raylib.CheckCollisionRecs(hitBox, tile.hitBox))
                    {
                        if (tile.state != TileState.VOID)
                        {
                            return tile.state;
                        }
                    }
                }
            }
            return TileState.VOID;
        }

        override public void Update()
        {
            float previousX = hitBox.x;
            float previousY = hitBox.y;

            velY += weight * Raylib.GetFrameTime();
            hitBox.y += velY * Raylib.GetFrameTime();

            if (checkTileMapCollision() == TileState.SOLID)
            {
                velY = 0;
                hitBox.y = previousY;
            }

            hitBox.x += velX * Raylib.GetFrameTime();

            if (checkTileMapCollision() == TileState.SOLID)
            {
                velX = 0;
                hitBox.x = previousX;
            }

            // faudra addapter pour n'importe quel type d'fps avec un timer 

            float friction = 0.95f;
            velX *= friction;

            if (Math.Abs(velX) < 0.01f)
            {
                velX = 0;
            }
        }
    }
}
