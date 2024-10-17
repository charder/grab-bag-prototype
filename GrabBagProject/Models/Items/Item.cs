namespace GrabBagProject.Models.Items
{
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool InInventory { get; set; }

        public Item() { }

        public virtual Item Build(Item item)
        {
            return Build(item.Name, item.Description, item.Value);
        }

        public Item Build(string name, string description, int value = 0)
        {
            Name = name;
            Description = description;
            Value = value;
            return this;
        }

        public override string ToString()
        {
            string value = $"{Name} - {Description}\n" +
                (InInventory ? $"Sell Value: {Value / 2}" : $"Cost: {Value}");
            return value;
        }
    }
}
