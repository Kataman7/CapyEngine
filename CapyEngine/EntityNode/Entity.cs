using Raylib_CsLo;
using System.Numerics;

namespace CapyEngine.EntityNode
{
    public class Entity
    {
        public Rectangle hitBox;
        public Color hitBoxColor;

        public Entity(int x, int y, float width, float height, int size)
        {
            hitBox = new Rectangle(x, y, width * size, height * size);
            hitBoxColor = Raylib.GRAY;
        }
        public virtual void Draw()
        {
            Raylib.DrawRectangleRec(hitBox, hitBoxColor);
        }

        public virtual void Update()
        {
            
        }
    }
}
