using CapyEngine.UtilNode;
using CapyEngine.UtilsNode;
using Raylib_CsLo;
using System.Numerics;
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
                    SetTile(x, y, ObjectID.VOID);
                }
            }
        }
        public TileMap(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] header = reader.ReadLine().Split(' ');
                width = int.Parse(header[0]);
                height = int.Parse(header[1]);
                tileSize = int.Parse(header[2]);

                tiles = new Tile[width * height];

                for (int y = 0; y < height; y++)
                {
                    string[] line = reader.ReadLine().Split(' ');
                    for (int x = 0; x < width; x++)
                    {
                        ObjectID tileID = (ObjectID)int.Parse(line[x]);
                        SetTile(x, y, tileID);
                    }
                }
            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"{width} {height} {tileSize}");

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        writer.Write((int)GetTile(x, y).id + " ");
                    }
                    writer.WriteLine();
                }
            }
        }

        public Tile GetTile(int x, int y)
        {
            return tiles[y * width + x];
        }

        public Tile GetTilePro(int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                return TilesFactory.Create(ObjectID.VOID, this, x, y);
            }
            return GetTile(x, y);
        }

        public void SetTile(int x, int y, ObjectID tileID)
        {
            tiles[y * width + x] = TilesFactory.Create(tileID, this, x, y);
        }

        public void SetTilePro(int x, int y, ObjectID tileID)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                return;
            }
            SetTile(x, y, tileID);
        }

        public void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (GetTile(x, y).id != ObjectID.VOID)
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
                    if (tile.id != ObjectID.VOID)
                    {
                        tile.Update();
                        tile.Draw();
                    }
                }
            }
        }

        public void Update()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL))
            {
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
                {
                    SaveToFile("save");
                }
            }
        }

        public void UpdateTiles()
        {
            foreach (Tile tile in tiles)
            {
                tile.UpdatePro();
            }
        }
    }
}
