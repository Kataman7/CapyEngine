using CapyEngine.TileNode;

namespace CapyEngine.GeneratorNode.TileMapGeneratorNode
{
    public class UpdateGenerator: ITileMapGenerator
    {
        private TileMap tileMap;
        private int iteration;

        public UpdateGenerator(TileMap tileMap, int iteration)
        {
            this.tileMap = tileMap;
            this.iteration = iteration;
        }

        public Task Generate()
        {
            for (int i = 0; i < iteration; i++)
            {
                tileMap.UpdateTiles();
            }
            return Task.CompletedTask;
        }
    }
}
