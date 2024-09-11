using CapyEngine.InventoryNode;
using CapyEngine.TextureNode;
using CapyEngine.UtilsNode;
using Raylib_CsLo;

namespace CapyEngine.EntityNode.GuiNode
{
    internal class InventoryDisplay : Entity
    {
        private Inventory inventory;
        private int width;
        private int height;
        private bool isOpen;
        private int size;
        private int padding;
        private Rectangle[,] rectangles;

        public InventoryDisplay(Inventory inventory, int width, int height, int x, int y, int size) : base(x, y, width, height, size)
        {
            this.inventory = inventory;
            this.width = width;
            this.height = height;
            this.isOpen = false;
            this.size = size;
            this.padding = 5;
            this.rectangles = new Rectangle[width,height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    rectangles[j,i] = new Rectangle(hitBox.x + j * size, hitBox.y + i * size, size, size);
                }
            }
        }

        public override void Draw()
        {
            if (isOpen)
            {
                int x = 0;
                int y = 0;
                base.Draw();
                foreach (var item in inventory.items)
                {
                    Raylib.DrawTexturePro(item.texture.texture, item.texture.hitBox, rectangles[x, y], GameManager.vecOrigin, 0, Raylib.WHITE);
                    Raylib.DrawText(Raylib.TextFormat("" + item.quantity), rectangles[x, y].x, rectangles[x, y].y, size/2, Raylib.WHITE);

                    x++;
                    if (x >= width)
                    {
                        x = 0;
                        y += 1;
                    }
                }
            }
        }

        public override void Update()
        {
            inventory.Update();
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
            {
                isOpen = !isOpen;
            }
        }
    }
}
