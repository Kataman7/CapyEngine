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
        }

        public virtual Task Create()
        {
            return Task.CompletedTask;
        }

        public virtual void Update()
        {
            tileMap.Update();
        }

        public virtual void Draw()
        {
            tileMap.DrawPro();
        }

    }
}
