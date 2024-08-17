using CapyEngine.EntityNode;
using System.Numerics;
using CapyEngine.TextureNode;
using Raylib_CsLo;

namespace CapyEngine.TileNode
{
    public class Tile : Entity
    {
        public TileID id;
        public TileState state;
        private Vector2 origin;
        private TextureNode.Texture texture;

        public Tile(TileID id, int x, int y, int size) : base(x*size, y*size, 1, 1, size)
        {
            this.id = id;
            origin = new Vector2(0, 0);
            texture = Textures.Get(id);
            state = TileStates.Get(id);
        }

        public Tile(Tile tile, int x, int y, int size) : this(tile.id, x, y, size) { }

        public Tile(TileID id, int x, int y, int size, TileState state) : this(id, x, y, size)
        {
            this.state = state;
        }

        public override void Draw()
        {
            //base.Draw();
            Raylib.DrawTexturePro(texture.texture, texture.hitBox, hitBox, origin, 0, Raylib.WHITE);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is Tile))
            {
                return false;
            }
            return id == ((Tile)obj).id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
