using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
	public class Player
	{
		private string _name = "";
        private int _type;
        private int _healths;
        private int _defense;
        private int _strength;
        private int _dexterity;
        private int _skill;
		private bool _is_live = true;

		public Player(string name, int type)
		{
			_name = name;
			_type = type;

			switch (type)
			{
				case 1:
                    _healths = 50;
                    _defense = 20;
                    _strength = 40;
                    _dexterity = 10;
                    _skill = 10;

					break;
				case 2:
                    _healths = 30;
                    _defense = 10;
                    _strength = 30;
                    _dexterity = 40;
                    _skill = 20;

					break;
				case 3:
                    _healths = 20;
                    _defense = 10;
                    _strength = 30;
                    _dexterity = 20;
                    _skill = 40;

					break;
            }
		}

		public bool TakeDamage(int damage)
		{
			if (damage > 0)
			{
				_healths -= damage;

				if (_healths <= 0)
				{
					_is_live = true;
				}

				return true;
			}
			else
			{
				return false;
			}
		}

		public (string, string, int, int, int, int, int) GetPlayerInformation
		{
			get
			{
				(string, string, int, int, int, int, int) information = ("", "", 0, 0, 0, 0, 0);

				information.Item1 = _name;
				information.Item3 = _healths;
				information.Item4 = _defense;
				information.Item5 = _strength;
				information.Item6 = _dexterity;
				information.Item7 = _skill;

				switch (_type)
				{
					case 1:
						information.Item2 = "Рыцарь";
						break;
					case 2:
						information.Item2 = "Охотник";
						break;
					case 3:
						information.Item2 = "Маг";
						break;
				}

				return information;
			}
		}
	}
}
