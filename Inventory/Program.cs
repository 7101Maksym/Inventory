namespace Inventory
{
	internal class Program
	{
		static private Get_string_by_id _getter = new Get_string_by_id();

		static Player SetPlayer()
		{
			string name, strType;
			int type;

            Dictionary<string, int> inform = new Dictionary<string, int>();


            Console.Write("Введите имя игрока: \n");

			name = Console.ReadLine();

			while (name == "")
			{
				Console.WriteLine("Неверный ввод");

				name = Console.ReadLine();
			}

			Console.Clear();

			Console.WriteLine("Выберите класс персонажа:\n1 - Рыцарь\n2 - Охотник\n3 - Маг");

			while(!int.TryParse(Console.ReadLine(), out type) || type > 3 || type < 1)
			{
				Console.WriteLine("Неверный ввод!");
			}

			Player player = new(name, type);

            inform = _getter.GetPlayerParametrs(type);
			strType = _getter.GetStringPlayerType(type);

			Console.WriteLine($"Создан персонаж с характеристиками:\nИмя: {name}\nТип: {strType}\nЗдоровье: {inform["_healths"]}\nЗащита: {inform["_defense"]}\nСила: {inform["_strength"]}\nЛовкость: {inform["_dexterity"]}\nИнтеллект: {inform["_skill"]}\n");

			Console.WriteLine("Нажмите любую клавишу:\n");
			Console.ReadKey();
			Console.Clear();

			return player;
		}

		static void PrintItemVariations()
		{
			Console.WriteLine("0 - Сварочный аппарат");
            Console.WriteLine("1 - Меч");
            Console.WriteLine("2 - Лук");
            Console.WriteLine("3 - Стрела");
            Console.WriteLine("4 - Слабое лечебное зелье");
            Console.WriteLine("5 - Лечебное зелье");
            Console.WriteLine("6 - Противоядие");
            Console.WriteLine("7 - Кираса");
            Console.WriteLine("8 - Шлем");
            Console.WriteLine("9 - Кольчужные ботинки");
        }

		static void Main(string[] args)
		{
			Player player = SetPlayer();

			Inventory inventory = new Inventory();
			Display_inventory display = new Display_inventory();
			
			Console.Clear();

			while (true)
			{
				Console.WriteLine("Нажмите клавишу I, чтобы открыть инвентарь, клавишу A, чтобы добавить предмет в инвентарь, клавишу R, чтобы удалить предмет из инвентаря, или любую другую клавишу, чтобы завершить программу (клавиши английской раскладки).");

				ConsoleKey k = Console.ReadKey().Key;

                if (k == ConsoleKey.I)
				{
					Console.Clear();
					display.PrintInventory(inventory.GetItems());
				}
				else if (k == ConsoleKey.A)
				{
                    Console.Clear();

                    Console.WriteLine("Введите номер добавляемого предмета: ");

					PrintItemVariations();

					int name;
					int count;

					while (!int.TryParse(Console.ReadLine(), out name) || name > 9 || name < 0)
					{
						Console.WriteLine("Неверный ввод!");
					}

					Console.WriteLine("Введите количество добавляемых предметов: ");

                    while (!int.TryParse(Console.ReadLine(), out count))
                    {
                        Console.WriteLine("Неверный ввод!");
                    }

					if (!inventory.AddItem(name, count))
					{
						Console.WriteLine("Неверный ввод!");
					}
					else
					{
						Console.WriteLine("Успешно добавлено!\n");
					}
                }
                else if (k == ConsoleKey.R)
                {
					Console.Clear();

                    Console.WriteLine("Введите номер удаляемого предмета: ");

                    PrintItemVariations();

                    int name;
                    int count;

                    while (!int.TryParse(Console.ReadLine(), out name) || name > 9 || name < 0)
                    {
                        Console.WriteLine("Неверный ввод!");
                    }

                    Console.WriteLine("Введите количество удаляемых предметов: ");

                    while (!int.TryParse(Console.ReadLine(), out count))
                    {
                        Console.WriteLine("Неверный ввод!");
                    }

                    if (!inventory.RemoveItem(name, count))
                    {
                        Console.WriteLine("Неверный ввод!");
                    }
                    else
                    {
                        Console.WriteLine("Успешно удалено!\n");
                    }
                }
                else
				{
					return;
				}
			}
		}
	}
}
