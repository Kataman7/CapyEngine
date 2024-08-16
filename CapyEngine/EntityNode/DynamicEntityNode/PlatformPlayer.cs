using CapyEngine.CameraNode;
using CapyEngine.EntityNode.GuiNode;
using CapyEngine.WorldNode;
using Raylib_CsLo;
using CapyEngine.TileNode;

namespace CapyEngine.EntityNode.DynamicEntityNode
{
    public class PlatformPlayer : DynamicEntity
    {
        private int jumpCount;
        private int jumpPower;
        private int jumpMax;
        private int speed;

        public PlatformPlayer(int x, int y, World world) : base(x, y, 0.98f, 1.98f, 10, 1000, world)
        {
            jumpCount = 0;
            jumpPower = 600;
            jumpMax = 3;
            speed = 300;
        }
        private void Moove(int direction)
        {
            hitBox.x += speed * direction * Raylib.GetFrameTime();
        }
        private void Jump()
        {
            if (jumpCount < jumpMax)
            {
                velY = -jumpPower;
                jumpCount++;
            }
        }
        private void Control()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                Jump();
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                Moove(1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                Moove(-1);
            }
        }
        public override void Update()
        {
            float previousX = hitBox.x;
            float previousY = hitBox.y;

            velY += weight * Raylib.GetFrameTime();
            hitBox.y += velY * Raylib.GetFrameTime();

            if (checkTileMapCollision() == TileState.SOLID)
            {
                if (velY > 0)
                {
                    jumpCount = 0;
                }
                velY = 0;
                hitBox.y = previousY;
            }

            Control();

            if (checkTileMapCollision() == TileState.SOLID)
            {
                hitBox.x = previousX;
            }
        }


    }
}
