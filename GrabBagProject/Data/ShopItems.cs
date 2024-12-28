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
            _weapons.Add(new Weapon().Build("Ion Cannon", "Killer blast.", 20,
                  new Attack(20),
                  new Cleave(),
                  new Sluggish(),
                  new CombatCost(5, ("Power", 4))
                ));
            #endregion

            #region HELMETS

            #endregion

            #region ARMOR

            #endregion

            #region BOOTS

            #endregion

            #region CHIPS
            _chips.Add(new Item().Build("Overclock Chip", "Push yourself to the limit.", 10,
                  new Pull(2),
                  new Locked(),
                  new Sacrifice(5),
                  new CombatCost(2)
            ));
            #endregion

            #region MISC
            _misc.Add(new Item().Build("Fiery Flask", "Healing item that refreshes its charges each fight.", 4,
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
