using CapyEngine.WorldNode;
using Raylib_CsLo;
using CapyEngine.TileNode;
using CapyEngine.TextureNode;
using CapyEngine.UtilsNode;
using System.Numerics;

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

        public PlatformPlayer(int x, int y, World world) : base(x, y, 2, 3, 10, 1300, world)
        {
            jumpCount = 0;
            jumpPower = 600;
            jumpMax = 3;
            speed = 15000;
            texture = Textures.Get(ObjectID.PLAYER_IDLE);
            origin = new Vector2(0, 0);
            direction = 1;
        }
        private void Moove(int direction)
        {
            //hitBox.x += speed * direction * Raylib.GetFrameTime();
            velX += speed * direction * Raylib.GetFrameTime();;
        }
        private void Jump()
        {
            if (jumpCount < jumpMax)
            {
                velY = -jumpPower;
                jumpCount++;
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
        }
        public override void Update()
        {
            Control();

            if (velX == 0)
            {
                texture = Textures.Get(ObjectID.PLAYER_IDLE);
            }
            else
            {
                texture = Textures.Get(ObjectID.PLAYER_RUN);
                direction = velX < 0 ? -1 : 1;
            }

            texture.Update();

            float previousX = hitBox.x;
            float previousY = hitBox.y;

            velY += weight * Raylib.GetFrameTime();
            hitBox.y += velY * Raylib.GetFrameTime();

            if (checkTileMapCollision() == TileState.SOLID)
            {
                if (velY > 0)
                {
                    jumpCount = 0;
                }
                hitBox.y = previousY;
                velY = -velY / 5;
            }

            hitBox.x += velX * Raylib.GetFrameTime();

            if (checkTileMapCollision() == TileState.SOLID)
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
        }

        public override void Draw()
        {

            bool movingLeft = velX < 0;
            bool movingRight = velX > 0;

            // Définir le rectangle source pour la texture
            Rectangle sourceRec  = new Rectangle(0, 0, direction * texture.texture.width, texture.texture.height);

            Raylib.DrawTexturePro(texture.texture, sourceRec, hitBox, origin, 0, Raylib.WHITE);
        }
    }
}
