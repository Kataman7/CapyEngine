using CapyEngine;
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
                Game.currentScene.Update();
                Game.currentScene.Draw();
            }

            Raylib.CloseWindow();
        }
    }
}