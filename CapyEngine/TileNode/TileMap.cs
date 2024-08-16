using CapyEngine.Node;
namespace CapyEngine.TileNode
{
    public class TileMap
    {
        public int width { get; }
        public int height { get; }
        public int tileSize { get; }
        private Tile[] tiles;

        public TileMap(int width, int height, int tileSize)
        {
            this.width = width;
            this.height = height;
            this.tileSize = tileSize;
            tiles = new Tile[width*height];
        }

        public Tile getTile(int x, int y)
        {
            return tiles[y * width + x];
        }

        public Tile getTilePro(int x, int y)
        {
            x = ((x % width) + width) % width;
            y = ((y % height) + height) % height;
            return tiles[y * width + x];
        }

        public void setTile(int x, int y, Tile tile)
        {
            tiles[y * width + x] = tile;
        }

        public void setTilePro(int x, int y, Tile tile)
        {
            x = ((x % width) + width) % width;
            y = ((y % height) + height) % height;
            tiles[y * width + x] = tile;
        }

        public void draw()
        {
            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if (getTile(x, y) != null)
                    {
                        getTile(x, y).Draw();
                    }
                }
            }
        }
    }
}
