namespace CapyEngine.InventoryNode
{
    public class Inventory
    {
        private List<Item> list;
        private int maxItem;
        public Inventory(int maxItem) 
        {
            list = new();
            this.maxItem = maxItem;
        }

        public bool Add(Item item)
        {
            Item? existingItem = list.FirstOrDefault(i => i.Equals(item) && i.quantity < i.quantityMax);

            if (existingItem != null)
            {
                existingItem.Combine(item);
                return true;
            }
            else if (list.Count() < maxItem)
            {
                list.Add(item);
                return true;
            }
            return false;
        }

        public bool Remove(Item item, int quantity)
        {
            item.quantity = -quantity;

            Item? existingItem = list.FirstOrDefault(i => i.Equals(item) && i.quantity < i.quantityMax);
            if (existingItem != null)
            {
                existingItem.Combine(item);
                if (existingItem.quantity <= 0)
                {
                    list.Remove(existingItem);
                }
                return true;
            }
            return false;
        }
            
    }
}
