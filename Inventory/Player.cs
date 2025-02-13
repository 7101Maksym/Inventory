using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
	public class Player
	{
		public string _name = "";
		public string _type;
		public int _healths;
		public int _defense;
		public int _strength;
		public int _dexterity;
		public int _skill;

		public Player(string name, int t, int healths, int defense, int strength, int dexterity, int skill)
		{
			_name = name;
			_healths = healths;
			_defense = defense;
			_strength = strength;
			_dexterity = defense;
			_skill = skill;

			if (t == 1)
			{
				_type = "Рыцарь";
			}
			else if (t == 2)
			{
				_type = "Охотник";
			}
			else
			{
				_type = "Маг";
			}
		}
	}
}
