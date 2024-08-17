using CapyEngine.TileNode;
using Raylib_CsLo;
using static System.Reflection.Metadata.BlobBuilder;
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

            for (int i = 0; i < width * height; i++)
            {
                tiles[i] = new Tile(TileID.VOID, 0, 0, tileSize);
            }
        }

        public Tile GetTile(int x, int y)
        {
            return tiles[y * width + x];
        }

        public Tile GetTilePro(int x, int y)
        {
            x = ((x % width) + width) % width;
            y = ((y % height) + height) % height;
            return GetTile(x, y);
        }

        public void SetTile(int x, int y, TileID tileID)
        {
            tiles[y * width + x] = new Tile(tileID, x, y, tileSize);
        }

        public void SetTilePro(int x, int y, TileID tileID)
        {
            x = ((x % width) + width) % width;
            y = ((y % height) + height) % height;
            SetTile(x, y, tileID);
        }

        public void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if (GetTile(x, y) != null && GetTile(x, y).id != TileID.VOID)
                    {
                        GetTile(x, y).Draw();
                    }
                }
            }
        }

        public void DrawPro()
        {
            int halfScreenW = Raylib.GetScreenWidth() / 2;
            int halfScreenH = Raylib.GetScreenHeight() / 2;

            int width = halfScreenW / tileSize + 2;
            int height = halfScreenH / tileSize + 2;

            float blockX = (Game.currentCamera.camera.target.X + halfScreenW) / tileSize;
            float blockY = (Game.currentCamera.camera.target.Y + halfScreenH) / tileSize;

            for (int y = (int)blockY - height; y < blockY + height; ++y)
            {
                for (int x = (int)blockX - width; x < blockX + width; ++x)
                {
                    Tile tile = GetTilePro(x, y);
                    if (tile != null)
                    {
                        tile.Draw();
                    }
                }
            }
        }
    }
}
