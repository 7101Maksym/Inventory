using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Item
    {
        private int _name;
        private int _count = 0;

        public Item(int name, int count)
        {
            _count = count;
            _name = name;
        }

        public int name
        {
            get
            {
                return _name;
            }
            init
            {
                _name = value;
            }
        }

        public int count
        {
            get
            {
                return _count; 
            }
        }

        public void add(int value)
        {
            _count += value;
        }

        public void remove(int value)
        {
            _count -= value;
        }
    }
}

