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
            tiles = new Tile[width * height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    SetTile(x, y, TileID.VOID);
                }
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
                for (int x = 0; x < width; x++)
                {
                    if (GetTile(x, y).id != TileID.VOID)
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

            float blockX = (GameManager.currentCamera.camera.target.X + halfScreenW) / tileSize;
            float blockY = (GameManager.currentCamera.camera.target.Y + halfScreenH) / tileSize;

            for (int y = (int)blockY - height; y < blockY + height; ++y)
            {
                for (int x = (int)blockX - width; x < blockX + width; ++x)
                {
                    Tile tile = GetTilePro(x, y);
                    if (tile.id != TileID.VOID)
                    {
                        tile.Draw();
                    }
                }
            }
        }
    }
}
