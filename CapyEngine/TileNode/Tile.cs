using CapyEngine.TileNode;
using CapyEngine.EntityNode;
using System.Numerics;
using CapyEngine.TextureNode;
using Raylib_CsLo;

namespace CapyEngine.Node
{
    public class Tile : Entity
    {
        public TileID id { get; set; }
        private Vector2 origin;
        private TextureNode.Texture texture;

        public Tile(TileID id, int x, int y, int size) : base(x, y, 1, 1, size)
        {
            this.id = id;
            origin = new Vector2(0, 0);
            texture = Textures.Get(id);
        }

        public override void Draw()
        {
            Raylib.DrawTexturePro(texture.texture, texture.hitBox, hitBox, origin, 0, Raylib.WHITE);
        }
    }
}
