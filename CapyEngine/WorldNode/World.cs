using CapyEngine.EntityNode.DynamicEntityNode;
using CapyEngine.TileNode;

namespace CapyEngine.WorldNode
{
    public class World
    {
        public TileMap tileMap;
        public List<DynamicEntity> entities;

        public World(int width, int height, int tileSize)
        {
            tileMap = new TileMap(width, height, tileSize);
            entities = new List<DynamicEntity>();
            Create();
        }

        public virtual void Create()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            tileMap.Draw();
        }

    }
}
