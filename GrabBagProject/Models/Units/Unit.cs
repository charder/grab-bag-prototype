namespace GrabBagProject.Models.Units
{
    internal class Unit
    {
        public int CurrentHealth { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public void BuildUnit()
        {
            CurrentHealth = Health;
        }
    }
}
