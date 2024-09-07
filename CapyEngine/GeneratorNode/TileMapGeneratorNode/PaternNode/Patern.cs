using CapyEngine.UtilsNode;
using CapyEngine.TileNode;

namespace CapyEngine.GeneratorNode.TileMapGeneratorNode.PaternNode
{
    public class Patern
    {
        public int[,] grid;
        public ObjectID tileIn;
        public ObjectID tileOut;
        public ObjectID neighbors;
        public double chanceToApply;

        public Patern(int[,] grid, ObjectID tileIn, ObjectID tileOut, ObjectID neighbors, double chanceToApply)
        {
            this.grid = grid;
            this.tileIn = tileIn;
            this.tileOut = tileOut;
            this.neighbors = neighbors;
            this.chanceToApply = chanceToApply;
        }

        public bool Check(Tile tile, int[,] grid)
        {
            return tile.id == tileIn && Equal(grid) && GameManager.random.NextDouble() > chanceToApply;
        }

        public bool Equal(int[,] grid)
        {
            if (this.grid.GetLength(0) != grid.GetLength(0) || this.grid.GetLength(1) != grid.GetLength(1))
            {
                return false;
            }

            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (this.grid[y, x] != grid[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
