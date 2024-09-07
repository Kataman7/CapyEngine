﻿using CapyEngine.UtilNode;
using CapyEngine.UtilsNode;
using Raylib_CsLo;

namespace CapyEngine.TextureNode
{
    public static class TexturesFactory
    {
        private static Dictionary<ObjectID, Texture> list;
        private static String root;

        static TexturesFactory()
        {
            root = "resources/textures/blocks/";

            list = new Dictionary<ObjectID, Texture> ()
            {
                { ObjectID.DIRT_GRASS, new Texture(root + "dirt_grass") },
                { ObjectID.DIRT, new Texture(root + "dirt") },
                { ObjectID.STONE, new Texture(root + "stone") },
                { ObjectID.VOID, new Texture(root + "void") },
                { ObjectID.VINE, new AnimatedTexture(root + "vine", 2, 0.8f) },
                { ObjectID.MINERAL_BLACK, new Texture(root + "mineral_black") },
                { ObjectID.MINERAL_PINK, new Texture(root + "mineral_pink") },
                { ObjectID.MINERAL_PURPLE, new Texture(root + "mineral_purple") },
                { ObjectID.MINERAL_WHITE, new Texture(root + "mineral_white") },
                { ObjectID.STONE_DIRT, new Texture(root + "stone_dirt") },
                { ObjectID.STONE_GRASS, new Texture(root + "stone_grass") },
                { ObjectID.GRASS, new Texture(root + "grass") }
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

        public static void Update()
        {
            foreach (var texture in list)
            {
                texture.Value.Update();
            }
        }
    }
}
