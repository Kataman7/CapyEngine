using CapyEngine.GeneratorNode.FloatGeneratorNode;
using CapyEngine.TileNode;
using CapyEngine.UtilsNode;

namespace CapyEngine.GeneratorNode.TileMapGeneratorNode.PaternNode
{
    public class PaternsGenerator: ITileMapGenerator
    {
        private TileMap tileMap;
        private List<Patern> paterns;

        public PaternsGenerator(TileMap tileMap, List<Patern> paterns)
        {
            this.tileMap = tileMap;
            this.paterns = paterns;
        }

        public Task Generate()
        {
            for (int x = 0; x < tileMap.width; x++)
            {
                for (int y = 0; y < tileMap.height; y++)
                {
                    Tile tile = tileMap.GetTile(x, y);
                    paterns.ForEach(patern =>
                    {
                        if (patern.Check(tile, NeighborsGenerator.GetNeighborsAround(tileMap, patern.neighbors, x, y)))
                        {
                            tileMap.SetTile(x, y, patern.tileOut);
                        }
                    });
                }
            }
            return Task.CompletedTask;
        }
    }
}
