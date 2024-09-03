using CapyEngine.TileNode;
using CapyEngine.UtilsNode;
using SharpNoise;
using SharpNoise.Builders;
using SharpNoise.Modules;

namespace CapyEngine.GeneratorNode
{
    public class ConwayRule
    {

        public int min;
        public int max;
        public int birth;

        public ConwayRule(int min, int max, int birth)
        {
            this.min = min;
            this.max = max;
            this.birth = birth;
        }

        public static ConwayRule conway = new ConwayRule(2, 3, 3);
    }

    public static class DuneGenerator
    {

        public static Random random = new Random();

        public static void RandomTileGeneration(TileMap tileMap, int x, int y, float chanceToLive, ObjectID livingValue, ObjectID deadValue, ObjectID? conditionValue)
        {
            if (conditionValue == null || tileMap.GetTile(x, y).id == conditionValue)
            {
                if (random.NextDouble() < chanceToLive)
                {
                    tileMap.SetTile(x, y, livingValue);
                }
                else
                {
                    tileMap.SetTile(x, y, deadValue);
                }
            }
        }

        public static void RandomGridGeneration(TileMap tileMap, float chanceToLive, ObjectID livingValue, ObjectID deadValue, ObjectID? conditionValue)
        {
            for (int y = 0; y < tileMap.height; y++)
            {
                for (int x = 0; x < tileMap.width; x++)
                {
                    RandomTileGeneration(tileMap, x, y, chanceToLive, livingValue, deadValue, conditionValue);
                }
            }
        }

        public static int CountNeighbor(TileMap tileMap, ObjectID neighbor, int x, int y)
        {
            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (!(i == 0 && j == 0))
                    {
                        int neighborX = x + i;
                        int neighborY = y + j;

                        if (tileMap.GetTilePro(neighborX, neighborY).id == neighbor)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public static int[,] CreateNeighborsGrid(TileMap tileMap, ObjectID livingValue)
        {
            int[,] neighborsGrid = new int[tileMap.width, tileMap.height];

            for (int y = 0; y < tileMap.height; y++)
            {
                for (int x = 0; x < tileMap.width; x++)
                {
                    neighborsGrid[x, y] = CountNeighbor(tileMap, livingValue, x, y);
                }
            }

            return neighborsGrid;
        }

        public static void NextCaveGeneration(TileMap tileMap, ObjectID livingValue, ObjectID deadValue)
        {
            int[,] neighborsGrid = CreateNeighborsGrid(tileMap, livingValue);

            for (int y = 0; y < tileMap.height; ++y)
            {
                for (int x = 0; x < tileMap.width; ++x)
                {
                    int neighbors = neighborsGrid[x, y];

                    if (neighbors < 4 && tileMap.GetTile(x, y).id == livingValue)
                    {
                        tileMap.SetTile(x, y, deadValue);
                    }
                    else if (neighbors > 4 && tileMap.GetTile(x, y).id == deadValue)
                    {
                        tileMap.SetTile(x, y, livingValue);
                    }
                }
            }
        }

        public static int[] altitudeGeneration(int width, int height, float drop, int bias)
        {
            int[] altitude = new int[width];
            double x = random.NextDouble();

            for (int i = 0; i < width; i++)
            {
                altitude[i] = (int)(Math.Sin(x) * height) + bias;
                x += drop;
            }

            return altitude;
        }

        public static void noisemap()
        {
            // The noise source - a simple Perlin noise generator will do for this sample
            var noiseSource = new Perlin
            {
                Seed = new Random().Next()
            };

            // Create a new, empty, noise map and initialize a new planar noise map builder with it
            var noiseMap = new NoiseMap();
            var noiseMapBuilder = new PlaneNoiseMapBuilder
            {
                DestNoiseMap = noiseMap,
                SourceModule = noiseSource
            };

            // Set the size of the noise map
            noiseMapBuilder.SetDestSize(10, 10);

            // Set the bounds of the noise mpa builder
            // These are the coordinates in the noise source from which noise values will be sampled
            noiseMapBuilder.SetBounds(-3, 3, -2, 2);

            // Build the noise map - samples values from the noise module above,
            // using the bounds coordinates we have passed in the builder
            noiseMapBuilder.Build();

            // Create a new image and image renderer

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine(noiseMap.GetValue(i, j));
                }
            }

        }
    }
}
