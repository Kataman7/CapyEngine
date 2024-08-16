using CapyEngine.EntityNode.DynamicEntityNode;
using CapyEngine.WorldNode;
using Raylib_CsLo;

namespace CapyEngine.SceneNode
{
    public class DuneScene : IScene
    {
        private World world;
        private PlatformPlayer player;

        public DuneScene()
        {
            world = new DuneWorld(100, 100, 5);
            player = new PlatformPlayer(0, 0, world);

            world.entities.Add(player);
            Game.currentCamera.target = player;
    }

        public void Update()
        {
            world.Update();
            Game.currentCamera.Update();
        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);
            Raylib.BeginMode2D(Game.currentCamera.camera);

            world.Draw();

            Raylib.EndMode2D();
            Raylib.DrawFPS(20, 20);
            Raylib.EndDrawing();
        }
    }
}
