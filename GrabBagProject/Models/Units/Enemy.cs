using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Modifiers;
using GrabBagProject.Models.Pieces;

namespace GrabBagProject.Models.Units
{
    internal class Enemy : Unit
    {
        public List<Modifier> Modifiers { get; set; }
        public Enemy(string name, int health, params Modifier[] modifiers)
        {
            Name = name;
            Health = health;
            Modifiers = modifiers.ToList();
            BuildUnit();
        }

        public override string ToString()
        {
            string value = base.ToString();

            value += $"\nAction:";
            Modifiers.ForEach(m => value += m.ToString());
            return value;
        }
    }
}
