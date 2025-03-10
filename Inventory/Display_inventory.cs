using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Display_inventory
    {
        private static Get_string_by_id _getter = new Get_string_by_id();

        public void PrintInventory(List <Item> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Инвентарь пуст!\n");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"Название: {_getter.GetName(items[i].name)}\nОписание: {_getter.GetDescription(items[i].name)}\nТип: {_getter.GetTypes(items[i].name)}\nКоличество: {items[i].count}\n\n");
                }
            }
        }
    }
}
