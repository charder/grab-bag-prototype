using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Stats
{
    internal class StatContainer
    {
        public Dictionary<string, int> StatDictionary = new();
        public bool Destroyed = false;
        public virtual void AddStat(string stat, int value)
        {
            if (StatDictionary.ContainsKey(stat))
            {
                StatDictionary[stat] += value;
                return;
            }
            StatDictionary.Add(stat, value);
        }

        public virtual void ReplaceStat(string stat, int value)
        {
            if (StatDictionary.ContainsKey(stat))
            {
                StatDictionary[stat] = value;
                return;
            }
            StatDictionary.Add(stat, value);
        }

        public virtual int GetStatValue(string stat)
        {
            return StatDictionary.ContainsKey(stat) ? StatDictionary[stat] : 0;
        }
    }
}
