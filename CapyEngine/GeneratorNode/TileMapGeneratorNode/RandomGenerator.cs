using CapyEngine.TileNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.GeneratorNode.TileMapGeneratorNode
{
    public class RandomGenerator : ITileMapGenerator
    {
        private TileMap tileMap;
        private ObjectID livingValue;
        private ObjectID deadValue;
        private ObjectID? conditionValue;
        private float chanceToLive;

        public RandomGenerator(TileMap tileMap, ObjectID livingValue, ObjectID deadValue, float chanceToLive, ObjectID? conditionValue)
        {
            this.tileMap = tileMap;
            this.livingValue = livingValue;
            this.deadValue = deadValue;
            this.chanceToLive = chanceToLive;
            this.conditionValue = conditionValue;
        }

        public void RandomTile(int x, int y)
        {
            if (conditionValue == null || tileMap.GetTile(x, y).id == conditionValue)
            {
                if (GameManager.random.NextDouble() < chanceToLive)
                {
                    tileMap.SetTile(x, y, livingValue);
                }
                else
                {
                    tileMap.SetTile(x, y, deadValue);
                }
            }
        }

        public void Generate()
        {
            for (int y = 0; y < tileMap.height; y++)
            {
                for (int x = 0; x < tileMap.width; x++)
                {
                    RandomTile(x, y);
                }
            }
        }
    }
}
