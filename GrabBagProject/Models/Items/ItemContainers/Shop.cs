namespace GrabBagProject.Models.Items.ItemHolders
{
    internal class Shop : ItemContainer
    {
        protected bool _canSell;
        public bool CanSell
        {
            get { return _canSell; }
        }
        public Shop(int capacity, bool canSell = true) : base(capacity) { _canSell = canSell; }

        public override string ToString()
        {
            string response = "Shop - To learn more about an item, type 's #' where # is the number associated with it:";
            for (int i = 0; i < _items.Count; i++)
            {
                Item item = _items[i];
                if (item != null)
                    response += $"\n{i}. {item.Name} - Cost: {item.Value}";
            }
            return response;
        }
    }
}
