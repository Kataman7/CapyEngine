using CapyEngine.TileNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.GeneratorNode.FloatGeneratorNode
{
    public class NeighborsGenerator : IFloatGenerator
    {
        private float[,] grid;
        private TileMap tileMap;
        private ObjectID neighbor;

        public NeighborsGenerator(TileMap tileMap, ObjectID neighbor)
        {
            this.tileMap = tileMap;
            this.neighbor = neighbor;
            grid = new float[tileMap.width, tileMap.height];
        }

        private int CountNeighbor(int x, int y)
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

        public float[,] Generate()
        {
            float[,] neighborsGrid = new float[tileMap.width, tileMap.height];

            for (int y = 0; y < tileMap.height; y++)
            {
                for (int x = 0; x < tileMap.width; x++)
                {
                    neighborsGrid[x, y] = CountNeighbor(x, y);
                }
            }

            return neighborsGrid;
        }

        public static int[,] GetNeighborsAround(TileMap tileMap, ObjectID livingValue, int x, int y)
        {
            int[,] neighbors = new int[3, 3];

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighborX = x + i;
                    int neighborY = y + j;

                    if (neighborX >= 0 && neighborX < tileMap.width && neighborY >= 0 && neighborY < tileMap.height)
                    {
                        neighbors[i + 1, j + 1] = (int)tileMap.GetTile(neighborX, neighborY).id;
                    }
                }
            }

            return neighbors;
        }
    }
}
