namespace GrabBagProject.Models.Items.ItemHolders
{
    internal abstract class ItemContainer
    {
        protected List<Item> _items;
        protected int _capacity;

        public ItemContainer(int capacity)
        {
            _items = new List<Item>();
            _capacity = capacity;
        }

        public bool HasSpace
        {
            get { return _items.Count < _capacity; }
        }

        public Item? GetItem(int index)
        {
            return index >= _items.Count ? null : _items[index];
        }

        public virtual bool AddItem(Item item)
        {
            if (_items.Count >= _capacity)
                return false;
            _items.Add(item);
            return true;
        }

        public virtual bool RemoveItem(Item item)
        {
            return _items.Remove(item);
        }
    }
}
