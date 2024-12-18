namespace GrabBagProject.Models.Items.ItemHolders
{
    internal class Inventory : ItemContainer
    {
        public int Gold { get; set; } = 999;

        // Inventory can only hold one of each of the following ItemTypes.
        protected Helmet? _helmet;
        protected Armor? _armor;
        protected Boots? _boots;

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
            // Single-Instance ItemType checks.
            if (item is Helmet)
            {
                if (_helmet is null)
                    _helmet = item as Helmet;
                else
                {
                    Console.WriteLine($"Cannot have more than one Helmet Item! You can sell your {_helmet.Name} to make space.");
                    return false;
                }
            }
            else if (item is Armor)
            {
                if (_armor is null)
                    _armor = item as Armor;
                else
                {
                    Console.WriteLine($"Cannot have more than one Armor Item! You can sell your {_armor.Name} to make space.");
                    return false;
                }
            }
            else if (item is Boots)
            {
                if (_boots is null)
                    _boots = item as Boots;
                else
                {
                    Console.WriteLine($"Cannot have more than one Boots Item! You can sell your {_boots.Name} to make space.");
                    return false;
                }
            }

            if (base.AddItem(item))
            {
                item.InInventory = true;
                return true;
            }
            return false;
        }

        public override bool RemoveItem(Item item)
        {
            // Single-Instance ItemType checks.
            _helmet = item == _helmet ? null : _helmet;
            _armor = item == _armor ? null : _armor;
            _boots = item == _boots ? null : _boots;

            if (base.RemoveItem(item))
            {
                item.InInventory = false;
                return true;
            }
            return false;
        }
    }
}
