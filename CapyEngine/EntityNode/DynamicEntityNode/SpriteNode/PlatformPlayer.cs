using CapyEngine.WorldNode;
using Raylib_CsLo;
using CapyEngine.TileNode;
using CapyEngine.TextureNode;
using CapyEngine.UtilsNode;
using System.Numerics;
using CapyEngine.UtilNode;
using CapyEngine.InventoryNode;
using CapyEngine.EntityNode.GuiNode;

namespace CapyEngine.EntityNode.DynamicEntityNode.SpriteNode
{
    public class PlatformPlayer : DynamicEntity
    {
        private int jumpCount;
        private int jumpPower;
        private int jumpMax;
        private int speed;
        private TextureNode.Texture texture;
        private Vector2 origin;
        private int direction;
        private Rectangle body;
        public InventoryPlayer inventory;

        public PlatformPlayer(int x, int y, World world) : base(x, y, 1.25f, 2.625f, 10, 1300, world)
        {
            jumpCount = 0;
            jumpPower = 600;
            jumpMax = 3;
            speed = 15000;
            texture = TexturesFactory.Get(ObjectID.PLAYER_IDLE);
            origin = new Vector2(0, 0);
            direction = 1;
            body = new Rectangle(x, y, 2 * world.tileMap.tileSize, 3 * world.tileMap.tileSize - 1);
            inventory = new InventoryPlayer(new Inventory(10*5), 5, 10, 0, 0, (int)(world.tileMap.tileSize * 1.2));
        }
        private void Moove(int direction)
        {
            //hitBox.x += speed * direction * Raylib.GetFrameTime();
            velX += speed * direction * Raylib.GetFrameTime(); ;
        }
        private void Jump()
        {
            if (jumpCount < jumpMax)
            {
                velY = -jumpPower;
                jumpCount++;
            }
        }

        private void Destroy()
        {
            Vector2 pos = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), GameManager.currentCamera.camera);
            world.tileMap.GetTilePro((int)pos.X / world.tileMap.tileSize, (int)pos.Y / world.tileMap.tileSize).Destroy(world);
            // for terraria like game
        }

        private void Build()
        {
            Vector2 pos = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), GameManager.currentCamera.camera);
            if (world.tileMap.GetTilePro((int)pos.X / world.tileMap.tileSize, (int) pos.Y / world.tileMap.tileSize).id == ObjectID.VOID)
            {
                Item? item = inventory.RemoveSelectedItem();
                if (item != null)
                {
                    world.tileMap.SetTilePro((int)pos.X / world.tileMap.tileSize, (int)pos.Y / world.tileMap.tileSize, item.id);
                }
            }
        }

        private void Control()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                Jump();
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                Moove(1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                Moove(-1);
            }
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            {
                Destroy();
            }
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                Build();
            }
        }
        public override void Update()
        {
            Control();
            inventory.Update();

            if (velY < -1 || velY > 1)
            {
                texture = TexturesFactory.Get(ObjectID.PLAYER_JUMP);
            }
            else if (velX == 0)
            {
                texture = TexturesFactory.Get(ObjectID.PLAYER_IDLE);
            }
            else
            {
                texture = TexturesFactory.Get(ObjectID.PLAYER_RUN);
            }

            if (velX != 0)
            {
                direction = velX < 0 ? -1 : 1;
            }

            float previousX = hitBox.x;
            float previousY = hitBox.y;

            velY += weight * Raylib.GetFrameTime();
            hitBox.y += velY * Raylib.GetFrameTime();

            if (checkTileMapCollision().Contains(TileState.SOLID))
            {
                if (velY > 0)
                {
                    jumpCount = 0;
                }
                hitBox.y = previousY;
                velY = -velY / 5;
            }

            hitBox.x += velX * Raylib.GetFrameTime();

            if (checkTileMapCollision().Contains(TileState.SOLID))
            {
                velX = 0;
                hitBox.x = previousX;
            }

            float friction = 0.8f;
            velX *= friction;

            if (Math.Abs(velX) < 0.01f)
            {
                velX = 0;
            }

            body.x = hitBox.x - 3 * (world.tileMap.tileSize / 8);
            body.y = hitBox.y - 3 * (world.tileMap.tileSize / 8);
        }

        public override void Draw()
        {
            Rectangle sourceRec = new Rectangle(0, 0, direction * texture.texture.width, texture.texture.height);
            Raylib.DrawTexturePro(texture.texture, sourceRec, body, origin, 0, Raylib.WHITE);
            //inventory.Draw();
            //base.Draw
        }
    }
}
