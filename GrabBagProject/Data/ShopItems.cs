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
            _weapons.Add(new Weapon().Build("Sword", "Basic sharp blade.", 4,
                  new Attack(6),
                  new CombatCost(1, ("Power", 2))
                ));
            _weapons.Add(new Weapon().Build("Magic Wand", "Basic magic weapon.", 4,
                  new Attack(6),
                  new Charge(1),
                  new Recharge(1),
                  new CombatCost(0, ("Magic", 2))
                ));
            #endregion

            #region HELMETS

            #endregion

            #region ARMOR

            #endregion

            #region BOOTS

            #endregion

            #region CHIPS

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
            items.Add(new Helmet().Build("Leather Helm", "Padded for protection.", 4,
                  new Armored(2)
                ));
            items.Add(new Armor().Build("Leather Armor", "Padded for protection.", 6,
                  new Armored(4)
                ));
            items.Add(new Boots().Build("Leather Boots", "Padded for protection.", 4,
                  new Armored(2)
                ));


            return items;
        }
    }
}
