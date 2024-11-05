namespace GrabBagProject.Models.Items.ItemModifiers
{
    internal class ItemModifier : Item
    {
        protected Item _item;

        public override Item Build(Item item)
        {
            _item = item;
            return base.Build(item);
        }

        public override string ToString()
        {
            return _item.ToString();
        }
    }
}
