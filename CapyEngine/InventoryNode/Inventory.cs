using CapyEngine.TileNode;
using CapyEngine.UtilsNode;
using Raylib_CsLo;

namespace CapyEngine.InventoryNode
{
    public class Inventory
    {
        public List<Item> items;
        private int maxItem;

        public Inventory(int maxItem) 
        {
            items = new();
            this.maxItem = maxItem;
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
            Item? existingItem = items.FirstOrDefault(i => i.Equals(item) && i.quantity < i.quantityMax);

            if (existingItem == null)
            {
                existingItem = items.FirstOrDefault(i => i.Equals(item));
            }

            if (existingItem != null)
            {
                existingItem.quantity -= quantity;
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
        }
    }
}
