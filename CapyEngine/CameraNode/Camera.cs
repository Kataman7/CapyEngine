using CapyEngine.EntityNode;
using Raylib_CsLo;

namespace CapyEngine.CameraNode
{
    public class Camera
    {
        public Camera2D camera;
        private int speed;
        public Entity ?target;
        public bool followTarget;

        public Camera(int speed, float zoom)
        {
            camera = new Camera2D();
            camera.zoom = zoom;
            this.speed = speed;
            followTarget = true;
            target = null;
        }


        public Camera(Entity target, int speed, float zoom) : this(speed, zoom)
        {
            this.target = target;
        }

        public void Update()
        {

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                followTarget = !followTarget;
            }

            if (followTarget && target != null)
            {
                camera.target.X = target.hitBox.x - Raylib.GetScreenWidth() / 2;
                camera.target.Y = target.hitBox.y - Raylib.GetScreenHeight() / 2;
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
    }
}
