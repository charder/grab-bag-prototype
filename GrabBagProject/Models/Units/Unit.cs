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

        public virtual void ClearArmor()
        {
            Armor = 0;
        }

        public virtual int TakeCorrosion(int damage)
        {
            int value = Math.Min(Armor, damage);
            Armor -= value;
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

        public virtual int GainHealth(int health)
        {
            int add = Math.Min(Health - CurrentHealth, health);
            CurrentHealth += add;
            return add;
        }

        public virtual int GainArmor(int armor)
        {
            Armor += armor;
            return armor;
        }
    }
}
