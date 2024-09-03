﻿using CapyEngine.EntityNode.DynamicEntityNode.SpriteNode;
using CapyEngine.SceneNode;
using CapyEngine.WorldNode;
using Raylib_CsLo;
using CapyEngine.CameraNode;
using CapyEngine.UtilNode;
using CapyEngine.GeneratorNode;

namespace CapyEngine.Exemple.Dune
{
    public class DuneScene : IScene
    {
        private World world;
        private PlatformPlayer player;
        private BasicMonster monster;

        public DuneScene()
        {
            world = new DuneWorld(1000, 1000, 30);
            player = new PlatformPlayer((world.tileMap.width / 2)*world.tileMap.tileSize, -world.tileMap.tileSize*20, world);
            monster = new BasicMonster(0, 0, world);

            //GameManager.currentCamera = new CameraSmooth(player, 1000, 1f, 350, 150);
            GameManager.currentCamera.target = player;

            world.entities.Add(player);
            world.entities.Add(monster);
            Raylib.SetTargetFPS(240);

            DuneGenerator.noisemap();
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
