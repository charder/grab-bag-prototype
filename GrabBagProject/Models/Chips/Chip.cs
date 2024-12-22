using GrabBagProject.Models.Items;
using GrabBagProject.Models.Modifiers;

namespace GrabBagProject.Models.Chips
{
    internal class Chip : Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public Chip() { }

        public Chip Build(string name, string description, int value = 0)
        {
            Name = name;
            Description = description;
            Value = value;
            return this;
        }
    }
}
