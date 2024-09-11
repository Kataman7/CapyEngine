using CapyEngine.EntityNode.DynamicEntityNode;
using CapyEngine.InventoryNode;
using CapyEngine.WorldNode;
using Raylib_CsLo;
using System.Numerics;
using CapyEngine.TileNode;
using CapyEngine.EntityNode.DynamicEntityNode.SpriteNode;
using CapyEngine.TextureNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.Exemple.Dune
{
    public class Drop : DynamicEntity
    {
        public Item stuff;

        public Drop(int x, int y, Tile stuff, World world) : base(x, y, 0.5f, 0.5f, 3, 500, world)
        {
            this.stuff = new Item(stuff.id, 100);
        }

        private void DropCollision(Drop dropA, Drop dropB)
        {
            dropA.alive = false;
            dropB.stuff.quantity += dropA.stuff.quantity;
            dropB.velY = -50;
        }

        public override void Update()
        {
            base.Update();
            Drop? max = null;
            foreach (var entity in world.entities)
            {
                if (this == entity || !entity.alive) continue;
                if (entity is Drop drop)
                {
                    if (stuff.id == drop.stuff.id)
                    {
                        if (Raylib.CheckCollisionCircleRec(new Vector2(entity.hitBox.x + entity.hitBox.width / 2, entity.hitBox.y + entity.hitBox.height / 2), range, hitBox))
                        {
                            if (max == null || drop.stuff.quantity > max.stuff.quantity) max = drop;
                        }
                        if (Raylib.CheckCollisionRecs(hitBox, drop.hitBox))
                        {
                            if (stuff.quantity >= drop.stuff.quantity) DropCollision(drop, this);
                            else DropCollision(this, drop);
                        }
                    }
                }
                else if (entity is PlatformPlayer player)
                {
                    if (Raylib.CheckCollisionRecs(player.hitBox, hitBox))
                    {
                        if (player.inventory.inventory.Add(new Item(stuff.id, stuff.quantity, 100))) alive = false;
                    }
                }
            }
            if (max != null)
            {
                velX += (max.hitBox.x - hitBox.x) * 15 * Raylib.GetFrameTime();
                velY += (max.hitBox.y - hitBox.y) * Raylib.GetFrameTime();
            }
            else
            {
                velX = velX / 2;
            }

            if (stuff.quantity == 0) alive = false;
        }

        public override void Draw()
        {
            Raylib.DrawTexturePro(stuff.texture.texture, stuff.texture.hitBox, hitBox, GameManager.vecOrigin, 0, Raylib.WHITE);
        }
    }
}
