using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Inventory
{
    public class Get_string_by_id
    {
        public string GetName(int id)
        {
            switch (id)
            {
                case 0:
                    return "Сварочный аппарат";
                case 1:
                    return "Меч";
                case 2:
                    return "Лук";
                case 3:
                    return "Стрела";
                case 4:
                    return "Слабое лечебное зелье";
                case 5:
                    return "Лечебное зелье";
                case 6:
                    return "Противоядие";
                case 7:
                    return "Кираса";
                case 8:
                    return "Шлем";
                case 9:
                    return "Кольчужные ботинки";
                default:
                    return "";
            }
        }

        public string GetDescription(int id)
        {
            switch (id)
            {
                case 0:
                    return "Как бы он сюда не попал, но с его помощью можно приделать отломаный кусок доспеха, а это главное.";
                case 1:
                    return "Обычная заточенная полоса железа.";
                case 2:
                    return "Может поразить далёкую цель.";
                case 3:
                    return "Хорошо сбалансированная, и далеко летящая стрела.";
                case 4:
                    return "Быстро заживляет неглубокие раны.";
                case 5:
                    return "Может заживить довольно сильные раны.";
                case 6:
                    return "Поможет, если вас ранили отравленным оружием.";
                case 7:
                    return "Тяжёлая, зато хорошо защищает.";
                case 8:
                    return "Защищает голову";
                case 9:
                    return "Защищают ноги.";
                default:
                    return "";
            }
        }

        public string GetTypes(int id)
        {
            switch (id)
            {
                case 0:
                    return "Неизвестно";
                case 1:
                    return "Оружие";
                case 2:
                    return "Оружие";
                case 3:
                    return "Оружие";
                case 4:
                    return "Зелья";
                case 5:
                    return "Зелья";
                case 6:
                    return "Зелья";
                case 7:
                    return "Экипировка";
                case 8:
                    return "Экипировка";
                case 9:
                    return "Экипировка";
                default:
                    return "";
            }
        }

        public Dictionary<string, int> GetPlayerParametrs(int type)
        {
            Dictionary<string, int> player_inform = new Dictionary<string, int>();

            switch (type)
            {
                case 1:
                    player_inform.Add("_healths", 50);
                    player_inform.Add("_defense", 20);
                    player_inform.Add("_strength", 40);
                    player_inform.Add("_dexterity", 10);
                    player_inform.Add("_skill", 10);

                    break;
                case 2:
                    player_inform.Add("_healths", 30);
                    player_inform.Add("_defense", 10);
                    player_inform.Add("_strength", 30);
                    player_inform.Add("_dexterity", 40);
                    player_inform.Add("_skill", 20);

                    break;
                case 3:
                    player_inform.Add("_healths", 20);
                    player_inform.Add("_defense", 10);
                    player_inform.Add("_strength", 30);
                    player_inform.Add("_dexterity", 20);
                    player_inform.Add("_skill", 40);

                    break;
            }

            return player_inform;
        }

        public string GetStringPlayerType(int type)
        {
            switch (type)
            {
                case 1:
                    return "Рыцарь";
                case 2:
                    return "Охотник";
                case 3:
                    return "Маг";
                default:
                    return "";
            }
        }
    }
}
