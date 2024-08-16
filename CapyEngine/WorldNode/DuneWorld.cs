using TerrariaLikeCs;
using CapyEngine.TileNode;
using CapyEngine.EntityNode.DynamicEntityNode;

namespace CapyEngine.WorldNode
{
    public class DuneWorld(int width, int height, int tileSize) : World(width, height, tileSize)
    {
        public override void Create()
        {
            Generator.RandomGridGeneration(tileMap, 0.5f, new Tile(TileID.GROUND, 0, 0, tileMap.tileSize), new Tile(TileID.VOID, 0, 0, tileMap.tileSize), null);
        }

        public override void Update()
        {
            foreach (var entity in entities)
            {
                entity.Update();
            }
        }

        public override void Draw()
        {
            tileMap.Draw();
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].alive)
                {
                    entities[i].Draw();
                }
                else
                {
                    entities.Remove(entities[i]);
                    i--;
                }
            }
        }
    }
}
