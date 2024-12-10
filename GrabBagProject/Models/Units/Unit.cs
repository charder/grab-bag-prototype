namespace GrabBagProject.Models.Units
{
    internal class Unit
    {
        public string Name { get; set; } = "";
        public int CurrentHealth { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public bool IsDead { get { return CurrentHealth <= 0; } }

        public void BuildUnit()
        {
            CurrentHealth = Health;
        }

        public override string ToString()
        {
            string value = $"\nName - {Name}\nHealth - {CurrentHealth}\\{Health}\nArmor - {Armor}";

            return value;
        }

        public virtual int TakeDamage(int damage)
        {
            int diff = Armor - damage;
            if (diff >= 0)
            {
                Armor = diff;
                return 0;
            }
            damage -= Armor;
            Armor = 0;
            return TakePierce(damage);
        }

        public virtual int TakePierce(int damage)
        {
            if (CurrentHealth <= damage)
                damage = CurrentHealth;
            CurrentHealth -= damage;

            return damage;
        }

        public virtual int GainArmor(int armor)
        {
            //TODO: ADD MAX ARMOR?
            Armor += armor;
            return armor;
        }
    }
}
