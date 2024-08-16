using CapyEngine.SceneNode;
using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Raylib.InitWindow(1280, 720, "CapyEngine");

            while (!Raylib.WindowShouldClose())
            {
                CurrentScene.scene.Update();
                CurrentScene.scene.Draw();
            }

            Raylib.CloseWindow();
        }
    }
}