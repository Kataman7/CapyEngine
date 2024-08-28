using CapyEngine.WorldNode;
using Raylib_CsLo;
using System.Numerics;

namespace CapyEngine.EntityNode.DynamicEntityNode.SpriteNode
{
    public class BasicMonster : DynamicEntity
    {
        public BasicMonster(int x, int y, World world) : base(x, y, 1, 2, 4, 1000, world)
        {

        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            base.Update();
            foreach (DynamicEntity entity in world.entities)
            {
                Vector2 pos = new Vector2(hitBox.X + hitBox.width / 2, hitBox.Y + hitBox.height / 2);
                if (Raylib.CheckCollisionCircleRec(pos, range, entity.hitBox))
                {
                    Vector2 direction = new Vector2(entity.hitBox.x - hitBox.X, entity.hitBox.y - hitBox.Y);

                    velX += direction.X * 0.3f;
                    return;
                }
            }
        }
    }
}
