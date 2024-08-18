using Raylib_CsLo;
using System.Numerics;
using CapyEngine.CameraNode;

namespace CapyEngine.EntityNode.GuiNode
{
    public class Cursor : Entity
    {
        private int size;

        public Cursor(int size) : base(0, 0, 1, 1, size)
        {
            Raylib.HideCursor();
            this.size = size;
            hitBoxColor = Raylib.WHITE;
        }

        public Vector2 getTileMapPos()
        {
            Vector2 vector = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), GameManager.currentCamera.camera);
            return new Vector2(vector.X / size, vector.Y / size);
        }

        public override void Draw()
        {
            base.Draw();
            Vector2 pos = Raylib.GetMousePosition() / size;
        }

        override public void Update()
        {
            Vector2 pos = Raylib.GetMousePosition();
            hitBox.x = pos.X;
            hitBox.y = pos.Y;
        }
    }
}
