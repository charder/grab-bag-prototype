using GrabBagProject.Models.Items.ItemModifiers;

namespace GrabBagProject.Models.Items
{
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool InInventory { get; set; }
        public List<ItemModifier> Modifiers = new List<ItemModifier>();

        public Item() { }

        public Item Build(string name, string description, int value = 0, params ItemModifier[] modifiers)
        {
            Name = name;
            Description = description;
            Value = value;
            Modifiers.AddRange(modifiers);
            return this;
        }

        public override string ToString()
        {
            string builtString = $"{Name} - {Description}";
            foreach(ItemModifier modifier in Modifiers)
                builtString += modifier.ToString();
            return builtString += CostString();
        }

        public virtual string CostString()
        {
            return "\n" + (InInventory ? $"Sell Value - {Value / 2}" : $"Cost - {Value}");
        }
    }
}
