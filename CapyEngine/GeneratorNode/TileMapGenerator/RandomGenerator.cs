using CapyEngine.TileNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.GeneratorNode.TileMapGenerator
{
    public static class RandomGenerator
    {
        public static void RandomTileGeneration(TileMap tileMap, int x, int y, float chanceToLive, ObjectID livingValue, ObjectID deadValue, ObjectID? conditionValue)
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
    }
}
