using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers
{
    /// <summary>
    /// Specifies Enemy cooldown functionality and conditionals.
    /// </summary>
    internal class EnemyCooldown : Modifier, IUsable, IAfterUse, IOnTurnEnd
    {
        bool _justUsed = false;
        int Cooldown { get; set; }
        protected int _currentCooldown = 0;
        public int CurrentCooldown { get { return _currentCooldown; } }
        public EnemyCooldown(int cooldown = 1)
        {
            Cooldown = cooldown;
        }

        public override string ToString()
        {
            string value = base.ToString();
            if (Cooldown > 0)
                value += $"\nCooldown - {Cooldown}";
            if (CurrentCooldown > 0)
                value += $"\nOn Cooldown - {CurrentCooldown}";
            return value;
        }

        public void GoOnCooldown()
        {
            _currentCooldown = Cooldown;
        }

        #region INTERFACES

        public bool IsUsable()
        {
            return _currentCooldown <= 0;
        }

        public void AfterUse()
        {
            _justUsed = true;
            GoOnCooldown();
        }

        public void OnTurnEnd()
        {
            if (!_justUsed && _currentCooldown > 0)
                _currentCooldown--;
            _justUsed = false;
        }

        #endregion
    }
}