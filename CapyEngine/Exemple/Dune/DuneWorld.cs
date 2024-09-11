using CapyEngine.GeneratorNode.TileMapGeneratorNode;
using CapyEngine.GeneratorNode.TileMapGeneratorNode.PaternNode;
using CapyEngine.UtilsNode;
using CapyEngine.WorldNode;

namespace CapyEngine.Exemple.Dune
{
    public class DuneWorld(int width, int height, int tileSize) : World(width, height, tileSize)
    {
        public override async Task Create()
        {
            RandomGenerator randomStone = new RandomGenerator(tileMap, ObjectID.STONE, ObjectID.VOID, 0.5f, null);
            CaveGenerator cave = new CaveGenerator(tileMap, ObjectID.STONE, ObjectID.VOID, 15);
            AltitudeGenerator altitude = new AltitudeGenerator(tileMap, 5, 0.16f, 20);
            PaternsGenerator paterns = new PaternsGenerator(tileMap, new List<Patern> { PaternFactory.VINE });
            MineralGenerator mineralBlackGenerator = new MineralGenerator(tileMap, ObjectID.MINERAL_BLACK, ObjectID.STONE, 0.07f, ObjectID.STONE, new ConwayRule { min = 1, max = 2, born = 3 }, 1);
            MineralGenerator mineralWhiteGenerator = new MineralGenerator(tileMap, ObjectID.MINERAL_WHITE, ObjectID.STONE, 0.03f, ObjectID.STONE, new ConwayRule { min = 1, max = 3, born = 3 }, 1);
            MineralGenerator mineralPurpleGenerator = new MineralGenerator(tileMap, ObjectID.MINERAL_PURPLE, ObjectID.STONE, 0.04f, ObjectID.STONE, new ConwayRule { min = 1, max = 2, born = 3 }, 1);
            MineralGenerator mineralPink = new MineralGenerator(tileMap, ObjectID.MINERAL_PINK, ObjectID.STONE, 0.03f, ObjectID.STONE, new ConwayRule { min = 1, max = 2, born = 3 }, 1);

            MineralGenerator stoneGrass = new MineralGenerator(tileMap, ObjectID.STONE_GRASS, ObjectID.STONE, 0.1f, ObjectID.STONE, new ConwayRule { min = 1, max = 2, born = 3 }, 2);
            MineralGenerator stoneDirt = new MineralGenerator(tileMap, ObjectID.STONE_DIRT, ObjectID.STONE, 0.03f, ObjectID.STONE, new ConwayRule { min = 1, max = 3, born = 3 }, 3);

            UpdateGenerator updateGenerator = new UpdateGenerator(tileMap, 20);

            RandomGenerator rddirt = new RandomGenerator(tileMap, ObjectID.DIRT, ObjectID.STONE, 0.015f, ObjectID.STONE);
            SpreadGenerator dirt = new SpreadGenerator(tileMap, ObjectID.DIRT, ObjectID.STONE, 20, new ConwayRule{ min = 1, max = 5, born = 10});


            await randomStone.Generate();
            await altitude.Generate();
            await cave.Generate();
            await paterns.Generate();

            await rddirt.Generate();
            await dirt.Generate();

            await mineralBlackGenerator.Generate();
            await mineralWhiteGenerator.Generate();
            await mineralPurpleGenerator.Generate();
            await mineralPink.Generate();
            await stoneDirt.Generate();
            await stoneGrass.Generate();
            await updateGenerator.Generate();
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
