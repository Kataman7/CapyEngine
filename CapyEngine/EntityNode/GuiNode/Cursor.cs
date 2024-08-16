using Raylib_CsLo;
using System.Numerics;
using CapyEngine.CameraNode;

namespace CapyEngine.EntityNode.GuiNode
{
    public class Cursor : Entity
    {
        private int tileSize;

        public Cursor(int tileSize, Camera camera) : base(0, 0, 0.2f, 0.2f, tileSize)
        {
            Raylib.HideCursor();
            this.tileSize = tileSize;
            hitBoxColor = Raylib.WHITE;
        }

        public Vector2 getTileMapPos()
        {
            Vector2 vector = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), Game.currentCamera.camera);
            return new Vector2(vector.X / tileSize, vector.Y / tileSize);
        }

        public override void Draw()
        {
            base.Draw();
            Vector2 pos = Raylib.GetMousePosition() / tileSize;
        }

        override public void Update()
        {
            Vector2 pos = Raylib.GetMousePosition();
            hitBox.x = pos.X;
            hitBox.y = pos.Y;
        }

    }
}
