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

        public void Add(Item item)
        {
            Item? existingItem = list.FirstOrDefault(i => i.Equals(item) && i.quantity < i.quantityMax);

            if (existingItem != null)
            {
                existingItem.Combine(item);
            }
            else if (list.LongCount() < maxItem)
            {
                list.Add(item);
            }
        }

        public void Remove(Item item, int quantity)
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
            }
        }
            
    }
}
