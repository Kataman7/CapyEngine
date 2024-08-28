using CapyEngine.TextureNode;
using CapyEngine.UtilsNode;

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
            texture = Textures.Get(id);
            quantity = quantityMax;
        }

        public void Combine(Item item)
        {
            quantity += item.quantity;
            item.quantity = 0;
        }
    }
}
