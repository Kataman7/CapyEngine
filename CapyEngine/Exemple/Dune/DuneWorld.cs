using CapyEngine.EntityNode;
using CapyEngine.GeneratorNode;
using CapyEngine.UtilsNode;
using CapyEngine.WorldNode;

namespace CapyEngine.Exemple.Dune
{
    public class DuneWorld(int width, int height, int tileSize) : World(width, height, tileSize)
    {
        public override void Create()
        {
            landGeneration();
            caveGeneration();
        }

        private void landGeneration()
        {
            int[] altitude = DuneGenerator.altitudeGeneration(tileMap.width, 5, 0.16f, 20);

            for (int x = 0; x < tileMap.width; x++)
            {
                for (int y = 0; y < tileMap.height; y++)
                {
                    if (y == altitude[x])
                    {
                        tileMap.SetTile(x, y, ObjectID.DIRT_GRASS);
                    }
                    else if (y > altitude[x] && y < altitude[x] + 3)
                    {
                        tileMap.SetTile(x, y, ObjectID.DIRT);
                    }
                    else if (y >= altitude[x] + 3 && y < altitude[x] + 6)
                    {
                        tileMap.SetTile(x, y, ObjectID.STONE);
                    }
                    else if (y >= altitude[x] + 6)
                    {
                        DuneGenerator.RandomTileGeneration(tileMap, x, y, 0.5f, ObjectID.STONE, ObjectID.VOID, null);
                    }
                }
            }
        }

        private void caveGeneration()
        {
            for (int i = 0; i < 15; i++)
            {
                DuneGenerator.NextCaveGeneration(tileMap, ObjectID.STONE, ObjectID.VOID);
            }
        }

        public override void Update()
        {
            tileMap.Update();
            int count = entities.Count;
            for (int i = 0; i < count; i++)
            {
                entities[i].Update();
            }
        }

        public override void Draw()
        {
            tileMap.DrawPro();
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
