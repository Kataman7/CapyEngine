using CapyEngine.TileNode;
using CapyEngine.UtilsNode;
using Raylib_CsLo;

namespace CapyEngine.InventoryNode
{
    public class Inventory
    {
        public List<Item> items;
        private int maxItem;
        private int selectedX;
        private int selectedY;

        public Inventory(int maxItem) 
        {
            items = new();
            this.maxItem = maxItem;
            selectedX = 0;
            selectedY = 0;
        }

        public bool Add(Item item)
        {
            Item? existingItem = items.FirstOrDefault(i => i.Equals(item) && i.quantity < i.quantityMax);

            if (existingItem != null)
            {
                existingItem.Combine(item);
                return true;
            }
            else if (items.Count() < maxItem)
            {
                items.Add(item);
                return true;
            }
            return false;
        }

        public bool Remove(Item item, int quantity)
        {
            item.quantity = -quantity;

            Item? existingItem = items.FirstOrDefault(i => i.Equals(item) && i.quantity < i.quantityMax);
            if (existingItem != null)
            {
                existingItem.Combine(item);
                if (existingItem.quantity <= 0)
                {
                    items.Remove(existingItem);
                }
                return true;
            }
            return false;
        }

        public void Update()
        {
            if (Raylib.GetMouseWheelMove() > 0)
            {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
                {
                    selectedY--;
                }
                else
                {
                    selectedX--;
                }
            }
            else if (Raylib.GetMouseWheelMove() < 0)
            {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
                {
                    selectedY++;
                }
                else
                {
                    selectedX++;
                }
            }
        }
    }
}
