using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Modifiers.Attack;
using GrabBagProject.Models.Modifiers.Block;
using GrabBagProject.Models.Modifiers.Cooldown;
using GrabBagProject.Models.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Data
{
    /// <summary>
    /// Contains a list of hard-coded items for testing in this prototype.
    /// </summary>
    class ShopItems
    {
        List<Item> _weapons = new();
        List<Item> _shields = new();
        List<Item> _helmets = new();
        List<Item> _armor = new();
        List<Item> _boots = new();
        List<Item> _misc = new();
        public ShopItems()
        {
            #region WEAPONS
            _weapons.Add(new Weapon().Build("Sword", "Basic sharp blade.", 4,
                  new Attack(6),
                  new CombatCost(1, ("Power", 2))
                ));
            #endregion

            #region SHIELDS

            #endregion
        }

        public ICollection<Item> GetShopItems()
        {
            List<Item> items = new();



            return items;
        }
    }
}
