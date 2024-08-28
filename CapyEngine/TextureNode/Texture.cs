using CapyEngine.EntityNode;
using Raylib_CsLo;

namespace CapyEngine.TextureNode
{
    public class Texture: Entity
    {
        public Raylib_CsLo.Texture texture; 
        public Texture(String imagePath) : base(0, 0, 0, 0, 1)
        {
            texture = Raylib.LoadTexture(imagePath);
            hitBox.width = texture.width;
            hitBox.height = texture.height;
        }

        public virtual void Unload()
        {
            Raylib.UnloadTexture(texture);
        }

        public override void Update()
        {

        }
    }

   
}
