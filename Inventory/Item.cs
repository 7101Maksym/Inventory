using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Item
    {
        public string _name;
        public string _description;
        public string _type;
        public int _count = 0;

        public Item(string name, string description, string type, int count)
        {
            _name = name;
            _description = description;
            _type = type;
            _count = count;
        }

        public int Count
        {
            get { return _count; }
            set { _count += value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
