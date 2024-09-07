using CapyEngine.GeneratorNode.FloatGeneratorNode;
using CapyEngine.TileNode;
using CapyEngine.UtilsNode;
using System.ComponentModel;

namespace CapyEngine.GeneratorNode.TileMapGeneratorNode
{
    internal class CaveGenerator
    {
        private TileMap tileMap;
        private ObjectID livingValue;
        private ObjectID deadValue;
        private int interation;

        public CaveGenerator(TileMap tileMap, ObjectID livingValue, ObjectID deadValue, int interation)
        {
            this.tileMap = tileMap;
            this.livingValue = livingValue;
            this.deadValue = deadValue;
            this.interation = interation;
        }

        private void NextGeneration()
        {
            float[,] neighborsGrid = new NeighborsGenerator(tileMap, livingValue).Generate();

            for (int y = 0; y < tileMap.height; ++y)
            {
                for (int x = 0; x < tileMap.width; ++x)
                {
                    int neighbors = (int)neighborsGrid[x, y];

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

        public void Generate()
        {
            for (int i = 0; i < interation; i++)
            {
                NextGeneration();
            }
        }

    }
}
