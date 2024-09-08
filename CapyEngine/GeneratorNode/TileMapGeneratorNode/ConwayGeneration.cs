using CapyEngine.GeneratorNode.FloatGeneratorNode;
using CapyEngine.TileNode;
using CapyEngine.UtilsNode;
using SharpNoise.Modules;

namespace CapyEngine.GeneratorNode.TileMapGeneratorNode
{
    public class ConwayRule
    {
        public int min;
        public int max;
        public int born;
    }

    public class ConwayGeneration : ITileMapGenerator
    {
        private TileMap tileMap;
        private ObjectID livingValue;
        private ObjectID deadValue;
        private ObjectID? conditionValue;
        private int interation;
        private NeighborsGenerator neighborsGenerator;
        private ConwayRule rule;

        public ConwayGeneration(TileMap tileMap, ObjectID livingValue, ObjectID deadValue, ObjectID? conditionValue, int interation, ConwayRule rule)
        {
            this.tileMap = tileMap;
            this.livingValue = livingValue;
            this.deadValue = deadValue;
            this.conditionValue = conditionValue;
            this.interation = interation;
            neighborsGenerator = new NeighborsGenerator(tileMap, livingValue);
            this.rule = rule;
        }

        public void NextGeneration()
        {
            float[,] neighborsGrid = neighborsGenerator.Generate();
            for (int y = 0; y < tileMap.height; y++)
            {
                for (int x = 0; x < tileMap.width; x++)
                {
                    Tile tile = tileMap.GetTile(x, y);
                    int neighbors = (int)neighborsGrid[x, y];
                    if (tile.id == livingValue)
                    {
                        if (neighbors < rule.min || neighbors > rule.max)
                        {
                            tileMap.SetTile(x, y, deadValue);
                        }
                    }
                    else if (tile.id == deadValue && neighbors == rule.born)
                    {
                        tileMap.SetTile(x, y, livingValue);
                    }
                }

            }
        }

        public Task Generate()
        {
            for (int i = 0; i < interation; i++)
            {
                NextGeneration();
            }
            return Task.CompletedTask;
        }
    }
}
