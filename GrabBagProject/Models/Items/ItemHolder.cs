﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items
{
    internal abstract class ItemHolder
    {
        protected List<Item> _items;
        protected int _capacity;

        public ItemHolder(int capacity)
        {
            _items = new List<Item>();
            _capacity = capacity;
        }

        public Item? GetItem(int index)
        {
            return index >= _items.Count ? null : _items[index];
        }

        public bool AddItem(Item item)
        {
            if (_items.Count >= _capacity)
                return false;
            _items.Add(item);
            return true;
        }

        public bool RemoveItem(Item item)
        {
            return _items.Remove(item);
        }
    }
}
