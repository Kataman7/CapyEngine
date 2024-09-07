using CapyEngine.UtilsNode;
using CapyEngine.TileNode;

namespace CapyEngine.GeneratorNode.TileMapGeneratorNode.PaternNode
{
    public static class PaternFactory
    {
        public static Patern VINE = new Patern(new int[,] {
            { (int) ObjectID.STONE, (int) ObjectID.STONE, (int) ObjectID.STONE },
            { 0, 0, 0 },
            { 0, 0, 0 }
        }, ObjectID.VOID, ObjectID.VINE, ObjectID.STONE, 0.5);
    }
}

