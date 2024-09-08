using CapyEngine.TileNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.GeneratorNode.TileMapGeneratorNode
{
    public class MineralGenerator
    {
        RandomGenerator randomGenerator;
        ConwayGeneration conwayGeneration;

        public MineralGenerator(TileMap tileMap, ObjectID livingValue, ObjectID deadValue, float chanceToLive, ObjectID? conditionValue, ConwayRule rule, int iterations)
        {
            randomGenerator = new RandomGenerator(tileMap, livingValue, deadValue, chanceToLive, conditionValue);
            conwayGeneration = new ConwayGeneration(tileMap, livingValue, deadValue, conditionValue, iterations, rule);
        }

        public async Task Generate()
        {
            await randomGenerator.Generate();
            await conwayGeneration.Generate();
        }
    }
}
