using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Offensive
{
    /// <summary>
    /// Attack deals damage, which can be blocked by armor.
    /// </summary>
    internal class Attack : Modifier, IAmAttack, IOnUse, ITargetable
    {
        public int Value { get; set; }
        public Attack(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nAttack {Value} - Deal {Value} damage to target";
            return value;
        }

        #region INTERFACES

        public void OnUse()
        {
            Snapshot snapshot = Game.ActiveController.Snapshot;

            var mods = ModifierHolder?.Modifiers;
            Corrosion? corrosion = Utils.FindModifier<Corrosion>(mods);
            Pierce? pierce = Utils.FindModifier<Pierce>(mods);

            foreach (Unit? target in snapshot.Targets)
            {
                if (target == null) continue;

                // Group Corrosion damage, if it exists
                if (corrosion is not null)
                {
                    int corrosionVal = corrosion.Value;
                    Console.WriteLine($"\n{snapshot?.User?.Name} Corroding {target.Name} for {corrosionVal}.");
                    target.TakeCorrosion(corrosionVal);
                }

                Console.WriteLine($"{snapshot?.User?.Name} Attacking {target.Name} for {Value}.");

                int damage = target.TakeDamage(Value);

                // Group Pierce damage, if it exists.
                if (pierce is not null)
                {
                    int pierceVal = pierce.Value;
                    Console.WriteLine($"\n{snapshot?.User?.Name} Pierce attacking {target.Name} for {pierceVal}.");
                    damage += target.TakePierce(pierceVal);
                }

                if (damage == 0) continue;

                (Game.ActiveController as CombatController)?.UnitDamaged(target, damage);
            }
        }

        #endregion
    }
}


