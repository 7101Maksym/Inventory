namespace Inventory
{
	internal class Program
	{
		static Player SetClassOfPlayer()
		{
			string name;
			int type;
			int healths;
			int defense;
			int strength;
			int dexterity;
			int skill;

			Console.Write("Введите имя игрока: \n");

			name = Console.ReadLine();

			while (name == "")
			{
				Console.WriteLine("Неверный ввод");

				name = Console.ReadLine();
			}

			Console.Clear();

			Console.WriteLine("Выберите класс персонажа:\n1 - Рыцарь\n2 - Охотник\n3 - Маг");

			while(!int.TryParse(Console.ReadLine(), out type))
			{
				Console.WriteLine("Неверный ввод!");
			}

			if (type == 1)
			{
				healths = 50;
				defense = 20;
				strength = 40;
				dexterity = 10;
				skill = 10;
			}
			else if (type == 2)
			{
				healths = 30;
				defense = 10;
				strength = 30;
				dexterity = 40;
				skill = 20;
			}
			else
			{
				healths = 20;
				defense = 10;
				strength = 30;
				dexterity = 20;
				skill = 40;
			}

			Console.WriteLine($"Создан персонаж с характеристиками:\nИмя: {name}\nТип: {type}\nЗдоровье: {healths}\nЗащита: {defense}\nСила: {strength}\nЛовкость: {dexterity}\nИнтеллект: {skill}\n");

			Player player = new(name, type, healths, defense, strength, dexterity, skill);

			Console.WriteLine("Нажмите любую клавишу:\n");
			Console.ReadKey();
			Console.Clear();

			return player;
		}

		static (string, string, string) GetStrParametrs(int id)
		{
			(string, string, string) parametrs;

			switch (id)
			{
				case 0:
					parametrs.Item1 = "Сварочный аппарат";
					parametrs.Item2 = "Как бы он сюда не попал, но с его помощью можно приделать отломаный кусок доспеха, а это главное.";
					parametrs.Item3 = "Неизвестно";
					break;
				case 1:
                    parametrs.Item1 = "Меч";
                    parametrs.Item2 = "Обычная заточенная полоса железа.";
                    parametrs.Item3 = "Оружие";
                    break;
                case 2:
                    parametrs.Item1 = "Лук";
                    parametrs.Item2 = "Может поразить далёкую цель.";
                    parametrs.Item3 = "Оружие";
                    break;
                case 3:
                    parametrs.Item1 = "Стрела";
                    parametrs.Item2 = "Хорошо сбалансированная, и далеко летящая стрела.";
                    parametrs.Item3 = "Оружие";
                    break;
                case 4:
                    parametrs.Item1 = "Слабое лечебное зелье";
                    parametrs.Item2 = "Быстро заживляет неглубокие раны.";
                    parametrs.Item3 = "Зелья";
                    break;
                case 5:
                    parametrs.Item1 = "Лечебное зелье";
                    parametrs.Item2 = "Может заживить довольно сильные раны.";
                    parametrs.Item3 = "Зелья";
                    break;
                case 6:
                    parametrs.Item1 = "Противоядие";
                    parametrs.Item2 = "Поможет, если вас ранили отравленным ножом.";
                    parametrs.Item3 = "Зелья";
                    break;
                case 7:
                    parametrs.Item1 = "Кираса";
                    parametrs.Item2 = "Тяжёлая, зато хорошо защищает.";
                    parametrs.Item3 = "Экипировка";
                    break;
                case 8:
                    parametrs.Item1 = "Шлем";
                    parametrs.Item2 = "Защищает голову";
                    parametrs.Item3 = "Экипировка";
                    break;
                case 9:
                    parametrs.Item1 = "Кольчужные ботинки";
                    parametrs.Item2 = "Защищают ноги.";
                    parametrs.Item3 = "Экипировка";
                    break;
				default:
                    parametrs.Item1 = "";
                    parametrs.Item2 = "";
                    parametrs.Item3 = "";
                    break;
            }

			return parametrs;
        }

		static void PrintInventory(List<Item> inventory)
		{
			for (int i = 0; i < inventory.Count; i++)
			{
				Console.Write($"Название - {inventory[i].Name}\nОписание - {inventory[i].Description}\nТип - {inventory[i].Type}\nКоличество - {inventory[i].Count}\n\n\n");
			}
		}

		static void AddItems(ref List<Item> items)
		{
            do
            {
redo:
                Console.WriteLine("Нажмите Enter, если хотите добавить предмет в инвентарь, или любую другую клавишу для завершения программы:\n");

                ConsoleKey a = Console.ReadKey().Key;

                if (a == ConsoleKey.Enter)
                {
                    Console.Write("Нажмите клавишу с цифрой, соответствующей объекту:\n1 - Меч\n2 - Лук\n3 - Стрела\n4 - Слабое лечебное зелье\n5 - Лечебное зелье\n6 - Противоядие\n7 - Кираса\n8 - Шлем\n9 - Кольчужные ботинки\n0 - Сварочный аппарат\n");

					int K;

					while(!int.TryParse(Console.ReadLine(), out K))
					{
						Console.WriteLine("Неверный ввод!");
					}

                    (string, string, string) parametrs = GetStrParametrs(K);

                    if (parametrs.Item1 == "")
                    {
                        Console.Clear();
                        Console.WriteLine("Неверный ввод!");

                        goto redo;
                    }

                    Console.Clear();

                    Console.WriteLine("Введите количество добавляемых объектов:");

                    int count;

                    while (!int.TryParse(Console.ReadLine(), out count))
                    {
                        Console.WriteLine("Неверный ввод!");
                    }

                    Item item = new Item(parametrs.Item1, parametrs.Item2, parametrs.Item3, count);

                    items.Add(item);
                }
                else
                {
                    break;
                }
            } while (true);
        }

		static void Main(string[] args)
		{
            Player player = SetClassOfPlayer();

			List<Item> items = new List<Item>();

			AddItems(ref items);

            Console.Clear();
            Console.WriteLine("Нажмите клавишу I, чтобы открыть инвентарь, или любую другую клавишу, чтобы завершить работу программы");

			if (Console.ReadKey().Key == ConsoleKey.I)
			{
				Console.Clear();
				PrintInventory(items);
				return;
			}
			else
			{
				return;
			}
		}
	}
}
