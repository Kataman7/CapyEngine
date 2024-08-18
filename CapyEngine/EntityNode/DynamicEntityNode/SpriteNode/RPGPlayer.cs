using CapyEngine.WorldNode;
using Raylib_CsLo;

namespace CapyEngine.EntityNode.DynamicEntityNode.SpriteNode
{
    public class RPGPlayer : DynamicEntity
    {
        private int dashCount;
        private int dashPower;
        private int dashMax;
        private int speed;

        public RPGPlayer(int x, int y, World world) : base(x, y, 0.98f, 1.98f, 10, 0, world)
        {
            dashCount = 0;
            dashPower = 600;
            dashMax = 3;
            speed = 30;
        }
        private void MooveX(int direction)
        {
            velX += speed * direction;
        }

        private void MooveY(int direction)
        {
            velY += speed * direction;
        }

        private void DashX()
        {
            if (dashCount < dashMax)
            {
                velX = -dashPower;
                dashCount++;
            }
        }

        private void DashY()
        {
            if (dashCount < dashMax)
            {
                velY = -dashPower;
                dashCount++;
            }
        }

        private void Control()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                MooveX(1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                MooveX(-1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                MooveY(-1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                MooveY(1);
            }
        }
        public override void Update()
        {
            Control();
            base.Update();
        }


    }
}
