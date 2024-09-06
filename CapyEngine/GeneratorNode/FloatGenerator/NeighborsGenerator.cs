using CapyEngine.TileNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.GeneratorNode.FloatGenerator
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
            grid = CreateNeighborsGrid(tileMap, neighbor);
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

        private float[,] CreateNeighborsGrid(TileMap tileMap, ObjectID livingValue)
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

        public float[,] Get()
        {
            return grid;
        }
    }
}
