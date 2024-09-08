using CapyEngine.GeneratorNode.FloatGeneratorNode;
using CapyEngine.TileNode;
using CapyEngine.UtilsNode;
namespace CapyEngine.GeneratorNode.TileMapGeneratorNode
{
    public class SpreadGenerator: ITileMapGenerator
    {
        TileMap tileMap;
        ObjectID livingValue;
        ObjectID deadValue;
        int iteration;
        ConwayRule rule;

        public SpreadGenerator(TileMap tilemap, ObjectID livingValue, ObjectID deadValue, int iteration, ConwayRule rule)
        {
            this.livingValue = livingValue;
            this.deadValue = deadValue;
            this.iteration = iteration;
            this.tileMap = tilemap;
            this.rule = rule;
        }

        private Task NextGeneration()
        {
            float[,] neighborsGrid = new NeighborsGenerator(tileMap, livingValue).Generate();
            for (int y = 0; y < tileMap.height; y++)
            {
                for (int x = 0; x < tileMap.width; x++)
                {
                    Tile tile = tileMap.GetTile(x, y);
                    int neighbors = (int)neighborsGrid[x, y];
                    if (tile.id == deadValue)
                    {
                        if (neighbors > rule.min)
                        {
                            tileMap.SetTile(x, y, livingValue);
                        }
                    }
                    else if (tile.id == livingValue)
                    {
                        if (neighbors < rule.min || neighbors > rule.max)
                        {
                            tileMap.SetTile(x, y, deadValue);
                        }
                    }
                }
            }
            return Task.CompletedTask;
        }

        public async Task Generate()
        {
            for (int i = 0; i < iteration; i++)
            {
                await NextGeneration();
            }
        }
    }
}
