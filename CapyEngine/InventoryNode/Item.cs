using CapyEngine.TextureNode;
using CapyEngine.UtilsNode;
using CapyEngine.TileNode;

namespace CapyEngine.InventoryNode
{
    public class Item
    {
        public int quantity;
        public ObjectID id;
        public Texture texture;
        public int quantityMax;  
        
        public Item(ObjectID id, int quantityMax)
        {
            this.id = id;
            texture = TexturesFactory.Get(id);
            quantity = 1;
            this.quantityMax = quantityMax;
        }

        public Item(ObjectID id, int quantity, int quantityMax) : this(id, quantityMax)
        {
            this.quantity = quantity;
        }

        public void Combine(Item item)
        {
            quantity += item.quantity;
            item.quantity = 0;
        }

        public bool Equals(Item item)
        {
            return id == item.id;
        }
    }
}
