using Raylib_CsLo;
using System.Numerics;

namespace CapyEngine.SceneNode
{
    public class BasicScene : IScene
    {
        private Rectangle rectangle;
        private Color color;
        private Vector2 origin;
        private float rotation;
        private float timer;
        private const float interval = 0.01f;

        public BasicScene()
        {
            rectangle = new Rectangle(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2, 200, 200);
            color = Raylib.WHITE;
            origin = new Vector2(rectangle.width / 2, rectangle.height / 2);
            rotation = 0;
            timer = 0;
            Raylib.SetTargetFPS(60000);
        }

        public void Update()
        {
            timer += Raylib.GetFrameTime();
            if (timer > interval)
            {
                color.r = (byte)((color.r + 1) % 256);
                color.g = (byte)((color.g + 2) % 256);
                color.b = (byte)((color.b + 3) % 256);
                rotation += 1;
                timer = 0;
            }
        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);
            Raylib.DrawRectanglePro(rectangle, origin, rotation, color);
            Raylib.EndMode2D();
            Raylib.EndDrawing();
        }

    }
}
