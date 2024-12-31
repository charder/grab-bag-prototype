using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Modifiers.Offensive;
using GrabBagProject.Models.Modifiers.Block;
using GrabBagProject.Models.Modifiers.Cooldown;
using GrabBagProject.Models.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrabBagProject.Models.Modifiers.Health;
using GrabBagProject.Models.Modifiers.Charge;
using GrabBagProject.Utilities;
using GrabBagProject.Models.Modifiers.Pieces;
using GrabBagProject.Models.Modifiers.Area;

namespace GrabBagProject.Data
{
    /// <summary>
    /// Contains a list of hard-coded items for testing in this prototype.
    /// </summary>
    class ShopItems
    {
        List<Item> _weapons = new();
        List<Item> _helmets = new();
        List<Item> _armor = new();
        List<Item> _boots = new();
        List<Item> _chips = new();
        List<Item> _misc = new();
        public ShopItems()
        {
            #region WEAPONS
            _weapons.Add(new Weapon().Build("Laser Pistol", "Hand held blaster.", 6,
                  new Attack(5),
                  new CombatCost(1, ("Power", 1))
                ));
            _weapons.Add(new Weapon().Build("Laser Repeater", "Rapid-fire blaster.", 8,
                  new Attack(6),
                  new CombatCost(0, ("Power", 1), ("Energy", 1))
                ));
            _weapons.Add(new Weapon().Build("Rail Gun", "Full pierce.", 16,
                  new Pierce(10),
                  new CombatCost(3, ("Power", 2))
                ));
            _weapons.Add(new Weapon().Build("Ion Cannon", "Killer blast.", 20,
                  new Attack(20),
                  new Cleave(),
                  new Sluggish(),
                  new CombatCost(5, ("Power", 4))
                ));
            _weapons.Add(new Weapon().Build("Gravity Club", "A forceful blast with every swing.", 20,
                  new Attack(10),
                  new Cleave(),
                  new CombatCost(2, ("Power", 3))
                ));
            _weapons.Add(new Weapon().Build("Autonomous Blade", "A blade of its own.", 10,
                  new Attack(6),
                  new CombatCost(2)
                ));
            _weapons.Add(new Weapon().Build("Autonomous Spear", "A spear of its own.", 10,
                  new Pierce(4),
                  new CombatCost(2)
                ));
            _weapons.Add(new Weapon().Build("Autonomous Warhammer", "A hammer of its own.", 14,
                  new Attack(8),
                  new Cleave(),
                  new CombatCost(4)
                ));
            _weapons.Add(new Item().Build("Autonomous Shield", "A shield of its own.", 10,
                  new Block(5),
                  new CombatCost(3)
                ));
            #endregion

            #region HELMETS
            _helmets.Add(new Helmet().Build("Red Visor", "All you see is red.", 12,
                  new Rush(1),
                  new CombatCost(1, ("Energy", 2))
                ));
            _helmets.Add(new Helmet().Build("Bubble Helmet", "Stay safe out there.", 10,
                  new Armored(2),
                  new Regenerate(1)
                ));
            _helmets.Add(new Helmet().Build("Linked Headband", "Control of the autonomous.", 16,
                  new Uplink(1)
                ));
            #endregion

            #region ARMOR
            _armor.Add(new Armor().Build("Light Suit", "Armored and agile.", 20,
                  new Armored(2),
                  new Block(4),
                  new CombatCost(0, ("Guard", 1))
                ));
            _armor.Add(new Armor().Build("Medium Suit", "Extra padding as necessary.", 20,
                  new Armored(5),
                  new Block(5),
                  new CombatCost(1, ("Guard", 1))
                ));
            _armor.Add(new Armor().Build("Heavy Suit", "Armored to the core.", 20,
                  new Armored(8),
                  new Block(8),
                  new CombatCost(2, ("Guard", 3))
                ));
            #endregion

            #region BOOTS
            _boots.Add(new Boots().Build("Heavy Boots", "Keeps you on your feet", 10,
                  new Armored(4)
                ));
            _boots.Add(new Boots().Build("Jet Boots", "Quick boost", 12,
                  new Armored(2),
                  new Swift(1),
                  new CombatCost(1, ("Energy", 2))
                ));
            #endregion

            #region CHIPS
            _chips.Add(new Item().Build("Overclock Chip", "Push yourself to the limit.", 10,
                  new Pull(2),
                  new Locked(),
                  new Sacrifice(5),
                  new CombatCost(2)
                ));
            _chips.Add(new Item().Build("Red Chip", "Plug it in for Power.", 10,
                  new Reload(2),
                  new Locked(),
                  new CombatCost(2, ("Utility", 1), ("Energy", 1))
                ));
            #endregion

            #region MISC
            _misc.Add(new Item().Build("Fiery Flask", "Healing item that refreshes its charges each fight.", 12,
              new Heal(5),
              new Charge(3),
              new Capacity(3),
              new CombatCost(1)
            ));
            #endregion
        }

        public ICollection<Item> GetShopItems()
        {
            List<Item> items = new();
            items.AddRange(Utils.GetRandomFromCollection(_weapons, 5));
            items.AddRange(Utils.GetRandomFromCollection(_helmets, 5));
            items.AddRange(Utils.GetRandomFromCollection(_armor, 5));
            items.AddRange(Utils.GetRandomFromCollection(_boots, 5));
            items.AddRange(Utils.GetRandomFromCollection(_chips, 5));
            items.AddRange(Utils.GetRandomFromCollection(_misc, 5));
            return items;
        }
    }
}
