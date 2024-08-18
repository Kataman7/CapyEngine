using Raylib_CsLo;
using System.Numerics;

namespace CapyEngine.CameraNode
{
    public class CameraSmooth : Camera
    {
        private float velX = 0;
        private float velY = 0;
        private Vector2 lastTargetPos = new();
        private float friction = 0.35f;
        private float lookAheadAmountX = 200f;
        private float lookAheadAmountY = 200f;

        public CameraSmooth(int speed, float zoom) : base(speed, zoom) { }

        public CameraSmooth(int speed, float zoom, float lookAheadAmountX, float lookAheadAmountY) : this(speed, zoom)
        { 
            this.lookAheadAmountX = lookAheadAmountX;
            this.lookAheadAmountY = lookAheadAmountY;
        }

        public void Control()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                followTarget = !followTarget;
            }

            if (followTarget && target != null)
            {
                Vector2 direction = new Vector2(target.hitBox.x - lastTargetPos.X, target.hitBox.y - lastTargetPos.Y);
                Vector2 lookAhead = new(direction.X * lookAheadAmountX, direction.Y * lookAheadAmountY);

                float targetX = target.hitBox.x - Raylib.GetScreenWidth() / 2 + lookAhead.X;
                float targetY = target.hitBox.y - Raylib.GetScreenHeight() / 2 + lookAhead.Y;

                float deltaX = targetX - camera.target.X;
                float deltaY = targetY - camera.target.Y;

                velX += deltaX * 0.5f;
                velY += deltaY * 0.5f;

                lastTargetPos = new Vector2(target.hitBox.x, target.hitBox.y);
            }
            else
            {
                float deltaTime = Raylib.GetFrameTime();

                if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    camera.target.X -= speed * deltaTime;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    camera.target.X += speed * deltaTime;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    camera.target.Y -= speed * deltaTime;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    camera.target.Y += speed * deltaTime;
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
        }
    }
}
