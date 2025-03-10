using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
	public class Inventory
	{
		private Get_string_by_id _getter = new Get_string_by_id();

		private List<Item> _items = new List<Item>();
		private List<int> _names = new List<int>();

		public List<Item> GetItems()
		{
			List<Item> i = new List<Item>();
			i = _items;

			return i;
		}

        private List<int> GetNames()
		{
			List<int> names = new(_items.Count);

			for (int i = 0; i < _items.Count; i++)
			{
				names.Add(_items[i].name);
			}

			return names;
		}

		private int InInventory(int name)
		{
			for (int i = 0; i < _names.Count; i++)
			{
				if (_names[i] == name)
				{
					return i;
				}
			}

			return -1;
		}

		private void OptimiseInventory()
		{
			for (int i = 0; i < _items.Count; i++)
			{
				if (_items[i].count == 0)
				{
					_items.RemoveAt(i);
				}
			}
		}

        public bool AddItem(int name, int count)
		{
			if (count > 0)
			{
				_names = GetNames();

				int index = InInventory(name);

				if (index != -1)
				{
					_items[index].add(count);
				}
				else
				{
					_items.Add(new Item(name, count));
				}

				return true;
			}
			else
			{
				return false;
			}
		}

		public bool RemoveItem(int name, int count)
		{
			if (count > 0)
			{
				_names = GetNames();

				int index = InInventory(name);

				if (index != -1)
				{
					if (_items[index].count >= count)
					{
						_items[index].remove(count);
						OptimiseInventory();
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
        }
	}
}
