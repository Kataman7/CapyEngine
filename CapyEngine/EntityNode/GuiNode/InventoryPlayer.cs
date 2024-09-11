using CapyEngine.InventoryNode;
using CapyEngine.TextureNode;
using CapyEngine.UtilsNode;
using Raylib_CsLo;

namespace CapyEngine.EntityNode.GuiNode
{
    public class InventoryPlayer : Entity
    {
        public Inventory inventory;
        private int width;
        private int height;
        private bool isOpen;
        private int size;
        private int padding;
        private Rectangle[,] rectangles;
        private int selectedX;
        private int selectedY;

        public InventoryPlayer(Inventory inventory, int width, int height, int x, int y, int size) : base(x, y, width, height, size)
        {
            this.inventory = inventory;
            this.width = width;
            this.height = height;
            this.isOpen = false;
            this.size = size;
            this.padding = 5;
            this.rectangles = new Rectangle[width, height];
            selectedX = 0;
            selectedY = 0;

            hitBox.width += padding * (width + 1);
            hitBox.height += padding * (height + 1);
            hitBoxColor = new Color(10, 10, 10, 160);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    rectangles[j, i] = new Rectangle(hitBox.x + j * size + padding * (j + 1), hitBox.y + i * size + padding * (i + 1), size, size);
                }
            }
        }

        public Item? GetSelectedItem()
        {
            if (selectedY * width + selectedX < inventory.items.Count)
            {
                return inventory.items[selectedY * width + selectedX];
            }
            return null;
        }

        public Item? RemoveSelectedItem()
        {
            Item? item = GetSelectedItem() ?? null;
            if (item != null)
            {
                if (inventory.Remove(item, 1))
                {
                    return item;
                }
            }

            return null;
        }

        public override void Draw()
        {
            if (isOpen)
            {
                base.Draw();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Raylib.DrawRectangleLinesEx(rectangles[x, y], 2, new Color(10, 10, 10, 40));
                        if (y * width + x < inventory.items.Count && inventory.items[y * width + x] != null)
                        {
                            Raylib.DrawTexturePro(inventory.items[y * width + x].texture.texture, inventory.items[y * width + x].texture.hitBox, rectangles[x, y], GameManager.vecOrigin, 0, Raylib.WHITE);
                            Raylib.DrawText(Raylib.TextFormat("" + inventory.items[y * width + x].quantity), rectangles[x, y].x, rectangles[x, y].y, size / 2, Raylib.WHITE);
                        }
                        if (x == selectedX && y == selectedY)
                        {
                            Raylib.DrawRectangleLinesEx(rectangles[x, y], 2, Raylib.WHITE);
                        }
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

            float mouseWheelMove = Raylib.GetMouseWheelMove();
            if (mouseWheelMove != 0)
            {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
                {
                    selectedY += mouseWheelMove > 0 ? -1 : 1;
                }
                else
                {
                    selectedX += mouseWheelMove > 0 ? -1 : 1;
                }
            }

            selectedX = (selectedX + width) % width;
            selectedY = (selectedY + height) % height;
        }
    }
}