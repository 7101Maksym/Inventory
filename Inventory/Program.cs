namespace Inventory
{
	internal class Program
	{
		static Player SetPlayer()
		{
			string name;
			int type;

            (string, string, int, int, int, int, int) inform;


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

            inform = player.GetPlayerInformation;

			Console.WriteLine($"Создан персонаж с характеристиками:\nИмя: {inform.Item1}\nТип: {inform.Item2}\nЗдоровье: {inform.Item3}\nЗащита: {inform.Item4}\nСила: {inform.Item5}\nЛовкость: {inform.Item6}\nИнтеллект: {inform.Item7}\n");

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

		static void PrintInventory(Inventory inventory)
		{
            (string[], string[], string[], int[]) inform = inventory.get_information_for_player;

			for (int i = 0; i < inform.Item1.Length; i++)
			{
				Console.WriteLine($"Название: {inform.Item1[i]}\nОписание: {inform.Item2[i]}\nТип: {inform.Item3[i]}\nКоличество: {inform.Item4[i]}\n\n");
			}
        }

		static void Main(string[] args)
		{
			Player player = SetPlayer();

			Inventory inventory = new Inventory();
			
			Console.Clear();

			while (true)
			{
				Console.WriteLine("Нажмите клавишу I, чтобы открыть инвентарь, клавишу A, чтобы добавить предмет в инвентарь, клавишу R, чтобы удалить предмет из инвенторя, или любую другую клавишу, чтобы завершить программу.");

				ConsoleKey k = Console.ReadKey().Key;

                if (k == ConsoleKey.I)
				{
					Console.Clear();
					PrintInventory(inventory);
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
                }
                else
				{
					return;
				}
			}
		}
	}
}

