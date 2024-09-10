using CapyEngine.InventoryNode;
using Raylib_CsLo;

namespace CapyEngine.EntityNode.GuiNode
{
    internal class InventoryDisplay : Entity
    {
        private Inventory inventory;
        private int width;
        private int height;
        private bool isOpen;

        public InventoryDisplay(Inventory inventory, int width, int height, int x, int y, int size) : base(x, y, width, height, size)
        {
            this.inventory = inventory;
            this.width = width;
            this.height = height;
            this.isOpen = false;
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
                    item.texture.Draw();
                    Console.WriteLine(item.texture);
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
