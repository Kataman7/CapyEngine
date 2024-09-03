using CapyEngine.UtilNode;
using CapyEngine.UtilsNode;
using Raylib_CsLo;

namespace CapyEngine.TextureNode
{
    public static class Textures
    {
        private static Dictionary<ObjectID, Texture> list;
        private static String root;

        static Textures()
        {
            root = "resources/textures/blocks/";

            list = new Dictionary<ObjectID, Texture> ()
            {
                { ObjectID.DIRT_GRASS, new Texture(root + "dirt_grass.png") },
                { ObjectID.DIRT, new Texture(root + "dirt.png") },
                { ObjectID.STONE, new Texture(root + "stone.png") },
                { ObjectID.VOID, new Texture(root + "void.png") }
            };

            root = "resources/textures/player/";

            list.Add(ObjectID.PLAYER_IDLE, new AnimatedTexture(root + "idle", 4, 0.1f));
            list.Add(ObjectID.PLAYER_RUN, new AnimatedTexture(root + "run", 4, 0.1f));
            list.Add(ObjectID.PLAYER_JUMP, new AnimatedTexture(root + "jump", 7, 0.1f));
        }

        public static Texture Get(ObjectID tileID)
        {
            return list[tileID];
        }

        public static void UnloadTexture()
        {
            foreach (var texture in list)
            {
                texture.Value.Unload();
            }
        }
    }
}
