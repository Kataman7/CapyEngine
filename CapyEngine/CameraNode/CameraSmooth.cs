using Raylib_CsLo;
using System.Numerics;

namespace CapyEngine.CameraNode
{
    public class CameraSmooth: Camera
    {
        private float velX = 0;
        private float velY = 0;
        private Vector2 lastPos = new();
        private float friction = 0.8f;

        public CameraSmooth(int speed, float zoom) : base(speed, zoom) { }

        public void Control()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                followTarget = !followTarget;
            }

            if (followTarget && target != null)
            {
                float targetX = target.hitBox.x - Raylib.GetScreenWidth() / 2;
                float targetY = target.hitBox.y - Raylib.GetScreenHeight() / 2;

                float deltaX = targetX - lastPos.X;
                float deltaY = targetY - lastPos.Y;

                velX += deltaX * 0.45f;
                velY += deltaY * 0.45f;
            }
            else
            {
                float deltaTime = Raylib.GetFrameTime();

                if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    velX -= speed * deltaTime;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    velX += speed * deltaTime;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    velY -= speed * deltaTime;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    velY += speed * deltaTime;
                }
            }
        }


        public override void Update()
        {
            Control();

            camera.target.X += velX * Raylib.GetFrameTime();
            camera.target.Y += velY * Raylib.GetFrameTime();

            velX *= friction;
            velY *= friction;

            if (Math.Abs(velX) < 0.1f)
            {
                velX = 0;
            }
            if (Math.Abs(velY) < 0.1f)
            {
                velY = 0;
            }

            lastPos = new(camera.target.X, camera.target.Y);
        }
    }
}
