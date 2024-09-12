using CapyEngine.TileNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.GeneratorNode.TileMapGeneratorNode
{
    public class AltitudeGenerator
    {
        private TileMap tileMap;
        private int height;
        private int width;
        private float drop;
        private int bias;

        public AltitudeGenerator(TileMap tileMap, int height, float drop, int bias)
        {
            this.tileMap = tileMap;
            this.height = height;
            this.width = tileMap.width;
            this.drop = drop;
            this.bias = bias;
        }

        public int[] CurvatureGeneration()
        {
            int[] altitude = new int[width];
            double x = GameManager.random.NextDouble();

            for (int i = 0; i < width; i++)
            {
                altitude[i] = (int)(Math.Sin(x) * height) + bias;
                x += drop;
            }

            return altitude;
        }

        public Task Generate()
        {
            int[] altitude = CurvatureGeneration();
            ObjectID[] decorations = new ObjectID[] { ObjectID.FLOWER_PINK, ObjectID.FLOWER_BLUE, ObjectID.FLOWER_PURPLE, ObjectID.FLOWER_WHITE, ObjectID.FLOWER_RED, ObjectID.GRASS, ObjectID.GRASS, ObjectID.GRASS, ObjectID.GRASS };

            for (int x = 0; x < tileMap.width; x++)
            {
                for (int y = 0; y < tileMap.height; y++)
                {
                    if (y < altitude[x] - 1)
                    {
                        tileMap.SetTile(x, y, ObjectID.VOID);
                    }
                    else if (y == altitude[x] - 1)
                    {
                        if (GameManager.random.Next(0, 100) < 50)
                        {
                            tileMap.SetTile(x, y, decorations[GameManager.random.Next(0, decorations.Length)]);
                        }
                        else
                        {
                            tileMap.SetTile(x, y, ObjectID.VOID);
                        }
                    }
                    else if (y == altitude[x])
                    {
                        tileMap.SetTile(x, y, ObjectID.DIRT_GRASS);
                    }
                    else if (y > altitude[x] && y < altitude[x] + 2)
                    {
                        tileMap.SetTile(x, y, ObjectID.DIRT);
                    }
                    else if (y >= altitude[x] + 2 && y < altitude[x] + 6)
                    {
                        tileMap.SetTile(x, y, ObjectID.STONE);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
