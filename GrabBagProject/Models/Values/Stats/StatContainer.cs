using GrabBagProject.Models.Values.Integer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Values.Stats
{
    internal class StatContainer
    {
        public Dictionary<string, Dictionary<StatContainer, List<IIntProperty>>> StatDictionary = new();
        public bool Destroyed = false;
        public virtual void AddStat(string stat, IIntProperty value, StatContainer? source = null)
        {
            // Source is only provided if the stat is temporary to the existance of the StatContainer. Otherwise, use the global Game.
            source = source ?? Game.Instance;
            Dictionary<StatContainer, List<IIntProperty>>? find;
            if (StatDictionary.TryGetValue(stat, out find))
            {
                List<IIntProperty> list;
                if (find.TryGetValue(source, out list))
                {
                    list.Add(value);
                }
                find.Add(source, new List<IIntProperty>() { value });
                return;
            }
            StatDictionary.Add(stat, new Dictionary<StatContainer, List<IIntProperty>>());
            StatDictionary[stat].Add(source, new List<IIntProperty>() { value });
        }

        public virtual int GetStatValue(string stat)
        {
            int value = 0;
            foreach(string key in StatDictionary.Keys)
            {
                var dict = StatDictionary[key];
                foreach (StatContainer statContainer in dict.Keys)
                {
                    if (statContainer.Destroyed)
                    {
                        dict.Remove(statContainer);
                        if (dict.Count == 0)
                        {
                            StatDictionary.Remove(key);
                            break;
                        }
                        continue;
                    }
                    foreach(IIntProperty statValue in dict[statContainer])
                    {
                        value += statValue.GetValue();
                    }
                }
            }
            return value;
        }
    }
}
