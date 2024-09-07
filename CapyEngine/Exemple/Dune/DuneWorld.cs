using CapyEngine.GeneratorNode.TileMapGeneratorNode;
using CapyEngine.GeneratorNode.TileMapGeneratorNode.PaternNode;
using CapyEngine.UtilsNode;
using CapyEngine.WorldNode;

namespace CapyEngine.Exemple.Dune
{
    public class DuneWorld(int width, int height, int tileSize) : World(width, height, tileSize)
    {
        public override void Create()
        {
            RandomGenerator randomStone = new RandomGenerator(tileMap, ObjectID.STONE, ObjectID.VOID, 0.5f, null);
            CaveGenerator cave = new CaveGenerator(tileMap, ObjectID.STONE, ObjectID.VOID, 15);
            AltitudeGenerator altitude = new AltitudeGenerator(tileMap, 5, 0.16f, 20);
            PaternsGenerator paterns = new PaternsGenerator(tileMap, new List<Patern> { PaternFactory.VINE });
            randomStone.Generate();
            altitude.Generate();
            cave.Generate();
            paterns.Generate();
        }

        public override void Update()
        {
            tileMap.Update();
            int count = entities.Count;
            for (int i = 0; i < count; i++)
            {
                entities[i].Update();
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].alive)
                {
                    entities[i].Draw();
                }
                else
                {
                    entities.Remove(entities[i]);
                    i--;
                }
            }
            tileMap.DrawPro();
        }
    }
}
