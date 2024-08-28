using CapyEngine.EntityNode;
using System.Numerics;
using CapyEngine.TextureNode;
using Raylib_CsLo;
using CapyEngine.UtilsNode;

namespace CapyEngine.TileNode
{
    public class Tile : Entity
    {
        public ObjectID id;
        public TileState state;
        private Vector2 origin;
        private TextureNode.Texture texture;

        public Tile(ObjectID id, int x, int y, int size) : base(x*size, y*size, 1, 1, size)
        {
            this.id = id;
            origin = new Vector2(0, 0);
            texture = Textures.Get(id);
            state = TileStates.Get(id);
        }

        public override void Draw()
        {
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

        public void Destroy()
        {
            id = ObjectID.VOID;
            texture = Textures.Get(id);
            state = TileStates.Get(id);
        }
    }
}
