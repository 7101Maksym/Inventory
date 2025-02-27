using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
	internal class Inventory
	{
		private List<Item> _items = new List<Item>();
		private List<int> _names = new List<int>();

		private (string[], string[], string[], int[]) _information_for_player;

		public (string[], string[], string[], int[]) get_information_for_player
		{
			get
			{
				UpdateInformationForPlayer();

				return _information_for_player;
            }
		}

		private void UpdateInformationForPlayer()
		{
			_information_for_player.Item1 = GetStringNames();
            _information_for_player.Item2 = GetStringDescriptions();
            _information_for_player.Item3 = GetStringTypes();
            _information_for_player.Item4 = GetCounts();
        }

		private string[] GetStringNames()
		{
			string[] strNames = new string[_items.Count];
			List<int> names = new List<int>(_items.Count);

			names = GetNames();

			for (int i = 0; i < names.Count; i++)
			{
				switch (names[i])
				{
					case 0:
						strNames[i] = "Сварочный аппарат";
						break;
					case 1:
                        strNames[i] = "Меч";
						break;
					case 2:
                        strNames[i] = "Лук";
						break;
					case 3:
                        strNames[i] = "Стрела";
						break;
					case 4:
						strNames[i] = "Слабое лечебное зелье";
						break;
					case 5:
						strNames[i] = "Лечебное зелье";
						break;
					case 6:
						strNames[i] = "Противоядие";
						break;
					case 7:
						strNames[i] = "Кираса";
						break;
					case 8:
						strNames[i] = "Шлем";
						break;
					case 9:
						strNames[i] = "Кольчужные ботинки";
						break;
				}
			}

			return strNames;
		}

		private string[] GetStringDescriptions()
		{
            string[] strDescriptions = new string[_items.Count];
            List<int> names = new List<int>(_items.Count);

            names = GetNames();

            for (int i = 0; i < names.Count; i++)
            {
                switch (names[i])
                {
                    case 0:
						strDescriptions[i] = "Как бы он сюда не попал, но с его помощью можно приделать отломаный кусок доспеха, а это главное.";
                        break;
                    case 1:
                        strDescriptions[i] = "Обычная заточенная полоса железа.";
                        break;
                    case 2:
                        strDescriptions[i] = "Может поразить далёкую цель.";
                        break;
                    case 3:
                        strDescriptions[i] = "Хорошо сбалансированная, и далеко летящая стрела.";
                        break;
                    case 4:
                        strDescriptions[i] = "Быстро заживляет неглубокие раны.";
                        break;
                    case 5:
                        strDescriptions[i] = "Может заживить довольно сильные раны.";
                        break;
                    case 6:
                        strDescriptions[i] = "Поможет, если вас ранили отравленным оружием.";
                        break;
                    case 7:
                        strDescriptions[i] = "Тяжёлая, зато хорошо защищает.";
                        break;
                    case 8:
                        strDescriptions[i] = "Защищает голову";
                        break;
                    case 9:
                        strDescriptions[i] = "Защищают ноги.";
                        break;
                }
            }

            return strDescriptions;
        }
		
		private string[] GetStringTypes()
		{
            string[] strTypes = new string[_items.Count];
            List<int> names = new List<int>(_items.Count);

            names = GetNames();

            for (int i = 0; i < names.Count; i++)
            {
                switch (names[i])
                {
                    case 0:
						strTypes[i] = "Неизвестно";
                        break;
                    case 1:
                        strTypes[i] = "Оружие";
                        break;
                    case 2:
                        strTypes[i] = "Оружие";
                        break;
                    case 3:
                        strTypes[i] = "Оружие";
                        break;
                    case 4:
                        strTypes[i] = "Зелья";
                        break;
                    case 5:
                        strTypes[i] = "Зелья";
                        break;
                    case 6:
                        strTypes[i] = "Зелья";
                        break;
					case 7:
                        strTypes[i] = "Экипировка";
                        break;
					case 8:
						strTypes[i] = "Экипировка";
						break;
					case 9:
						strTypes[i] = "Экипировка";
						break;
				}
            }

            return strTypes;
        }

		private int[] GetCounts()
		{
			int[] counts = new int[_items.Count];

			for (int i = 0; i < _items.Count; i++)
			{
				counts[i] = _items[i].count;
			}

			return counts;
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
					_items[index].add = count;
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
						_items[index].remove = count;
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
