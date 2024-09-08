using CapyEngine.EntityNode;
using System.Numerics;
using CapyEngine.TextureNode;
using Raylib_CsLo;
using CapyEngine.UtilsNode;
using CapyEngine.WorldNode;
using CapyEngine.Exemple.Dune;

namespace CapyEngine.TileNode
{
    public class Tile : Entity
    {
        public ObjectID id;
        public TileState state;
        protected TextureNode.Texture texture;

        public Tile(ObjectID id, int x, int y, int size) : base(x*size, y*size, 1, 1, size)
        {
            this.id = id;
            texture = TexturesFactory.Get(id);
            state = TileStates.Get(id);
        }

        public override void Draw()
        {
            Raylib.DrawTexturePro(texture.texture, texture.hitBox, hitBox, GameManager.vecOrigin, 0, Raylib.WHITE);
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

        private void Set(ObjectID id)
        {
            this.id = id;
            texture = TexturesFactory.Get(id);
            state = TileStates.Get(id);
        }

        public void Destroy()
        {
            Set(ObjectID.VOID);
        }

        public void Destroy(World world)
        {
            if (id != ObjectID.VOID)
            {
                world.entities.Add(new Drop((int)(hitBox.X + hitBox.width / 4), (int)(hitBox.y + hitBox.width / 4), this, world));
                Destroy();
            }
        }

        public virtual void UpdatePro()
        {
            base.Update();
        }
    }
}
