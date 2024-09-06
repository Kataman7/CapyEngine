using CapyEngine.EntityNode.DynamicEntityNode.SpriteNode;
using CapyEngine.Exemple.Dune;
using CapyEngine.SceneNode;
using CapyEngine.UtilsNode;
using CapyEngine.WorldNode;
using Raylib_CsLo;
using System.Numerics;

namespace CapyEngine.Exemple.UnderGround
{
    public class UGScene : IScene
    {
        private World world;
        private RPGPlayer player;

        public UGScene()
        {
            world = new DuneWorld(1000, 1000, 30);
            player = new RPGPlayer(0, 0, world);
            GameManager.currentCamera.camera.target = new Vector2(player.hitBox.x, player.hitBox.y);
            world.entities.Add(player);
            GameManager.currentCamera.target = player;
            Raylib.SetTargetFPS(240);
        }

        public void Update()
        {
            world.Update();
            GameManager.currentCursor.Update();
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
            GameManager.currentCursor.Draw();
            Raylib.EndDrawing();
        }
    }
}
