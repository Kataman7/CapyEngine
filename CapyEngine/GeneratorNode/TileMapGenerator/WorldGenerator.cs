using CapyEngine.TileNode;
using CapyEngine.UtilsNode;
using CapyEngine.GeneratorNode.FloatGenerator;
using System;

namespace CapyEngine.GeneratorNode.TileMapGenerator
{
    internal class WorldGenerator
    {
        public static void NextCaveGeneration(TileMap tileMap, ObjectID livingValue, ObjectID deadValue)
        {
            float[,] neighborsGrid = new NeighborsGenerator(tileMap, livingValue).Get();

            for (int y = 0; y < tileMap.height; ++y)
            {
                for (int x = 0; x < tileMap.width; ++x)
                {
                    int neighbors = (int) neighborsGrid[x, y];

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
            double x = GameManager.random.NextDouble();

            for (int i = 0; i < width; i++)
            {
                altitude[i] = (int)(Math.Sin(x) * height) + bias;
                x += drop;
            }

            return altitude;
        }
    }
}
