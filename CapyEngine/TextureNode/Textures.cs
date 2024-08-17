using CapyEngine.TileNode;
using Raylib_CsLo;

namespace CapyEngine.TextureNode
{
    public static class Textures
    {
        private static Dictionary<TileID, Texture> list;
        private static String root;

        static Textures()
        {
            root = "resources/textures/";

            list = new Dictionary<TileID, Texture> ()
            {
                { TileID.DIRT_GRASS, new Texture(root + "dirt_grass.png") },
                { TileID.DIRT, new Texture(root + "dirt.png") },
                { TileID.STONE, new Texture(root + "stone.png") },
                { TileID.VOID, new Texture(root + "void.png") }
            };
        }

        public static Texture Get(TileID tileID)
        {
            return list[tileID];
        }

        public static void UnloadTexture()
        {
            foreach (var texture in list)
            {
                Raylib.UnloadTexture(texture.Value.texture);
            }
        }
    }
}
