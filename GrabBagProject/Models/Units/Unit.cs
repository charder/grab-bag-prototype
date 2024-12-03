namespace GrabBagProject.Models.Units
{
    internal class Unit
    {
        public string Name { get; set; } = "";
        public int CurrentHealth { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public void BuildUnit()
        {
            CurrentHealth = Health;
        }

        public override string ToString()
        {
            string value = $"\nName - {Name}\nHealth - {CurrentHealth}\\{Health}\nArmor - {Armor}";

            return value;
        }
    }
}
