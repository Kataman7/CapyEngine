using CapyEngine;
using CapyEngine.TextureNode;
using Raylib_CsLo;

namespace TerrariaLikeCs
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            Raylib.InitWindow(1280, 720, "CapyEngine");

            while (!Raylib.WindowShouldClose())
            {
                GameManager.currentScene.Update();
                GameManager.currentScene.Draw();
            }

            Raylib.CloseWindow();
            Textures.UnloadTexture();
            return Task.CompletedTask;
        }
    }
}