namespace GrabBagProject.Models.Items.ItemHolders
{
    internal class Inventory : ItemHolder
    {
        public int Gold { get; set; }
        public Inventory(int capacity) : base(capacity) { }

        public override string ToString()
        {
            string response = $"Inventory [{_items.Count}/{_capacity}] - To learn more about an item, type 'i #' where # is the number associated with it:";
            // Items List
            for (int i = 0; i < _items.Count; i++)
            {
                Item item = _items[i];
                if (item != null)
                    response += $"\n{i}. {item.Name}";
            }
            // Gold
            response += $"\nCurrent Gold: {Gold}";
            return response;
        }

        public override bool AddItem(Item item)
        {
            if (base.AddItem(item))
            {
                item.InInventory = true;
                return true;
            }
            return false;
        }

        public override bool RemoveItem(Item item)
        {
            if (base.RemoveItem(item))
            {
                item.InInventory = false;
                return true;
            }
            return false;
        }
    }
}
