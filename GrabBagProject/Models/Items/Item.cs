using GrabBagProject.Models.Modifiers;
using GrabBagProject.Models.Stats;

namespace GrabBagProject.Models.Items
{
    internal class Item : StatContainer, IModifierHolder
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool InInventory { get; set; }
        public List<Modifier> Modifiers { get; set; }

        public Item() { }

        public Item Build(string name, string description, int value = 0, params Modifier[] modifiers)
        {
            Name = name;
            Description = description;
            Value = value;
            Modifiers = [.. modifiers];
            Modifiers.ForEach(m => m.ModifierHolder = this);
            return this;
        }

        public override string ToString()
        {
            string builtString = $"{Name} - {Description}";
            foreach(Modifier modifier in Modifiers)
                builtString += modifier.ToString();
            return builtString += CostString();
        }

        public virtual string CostString()
        {
            return "\n" + (InInventory ? $"Sell Value - {Value / 2}" : $"Cost - {Value}");
        }
    }
}
