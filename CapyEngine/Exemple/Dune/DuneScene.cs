using CapyEngine.EntityNode.DynamicEntityNode.SpriteNode;
using CapyEngine.EntityNode.GuiNode;
using CapyEngine.SceneNode;
using CapyEngine.WorldNode;
using Raylib_CsLo;

namespace CapyEngine.Exemple.Dune
{
    public class DuneScene : IScene
    {
        private World world;
        private PlatformPlayer player;
        private Cursor cursor;

        public DuneScene()
        {
            world = new DuneWorld(1000, 1000, 30);
            player = new PlatformPlayer(world.tileMap.width / 2, world.tileMap.height / 2, world);
            cursor = new Cursor((int)(world.tileMap.tileSize * 0.3));

            world.entities.Add(player);
            GameManager.currentCamera.target = player;
            Raylib.SetTargetFPS(60);
        }

        public void Update()
        {
            world.Update();
            cursor.Update();
            GameManager.currentCamera.Update();
        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);
            Raylib.BeginMode2D(GameManager.currentCamera.camera);

            world.Draw();

            Raylib.EndMode2D();
            Raylib.DrawFPS(20, 20);
            cursor.Draw();
            Raylib.EndDrawing();
        }
    }
}
