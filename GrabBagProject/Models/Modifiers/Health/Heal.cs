using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Modifiers.Area;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Health
{
    /// <summary>
    /// Heal damage taken.
    /// </summary>
    internal class Heal : Modifier, IOnUse
    {
        public int Value { get; set; }
        public Heal(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nHeal {Value} - Gain {Value} health";
            return value;
        }

        #region INTERFACES

        public void OnUse()
        {
            Snapshot snapshot = Game.ActiveController.Snapshot;

            Unit? user = snapshot?.User;
            if (user is null) return;

            int heal;

            // Medic Modifier check.
            Enemy? enemy = user as Enemy;
            if (enemy is not null)
            {
                Medic? medic = Utils.FindModifier<Medic>(enemy.Modifiers);
                if (medic is not null)
                {
                    CombatController? controller = Game.ActiveController as CombatController;
                    controller?.ActiveEnemies.ForEach(e =>
                    {
                        if (e == user)
                            Console.WriteLine($"{user.Name} Heals for {Value}.");
                        else
                            Console.WriteLine($"{user.Name} Heals {e.Name} for {Value}.");
                        heal = e.GainHealth(Value);
                    });
                    return;
                }
            }

            Console.WriteLine($"{user.Name} Heals for {Value}.");
            heal = user.GainHealth(Value);
            return;
        }

        #endregion
    }
}


