using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
	public class Player
	{
		private Get_string_by_id _getter = new Get_string_by_id();

		private string _name = "";
        private int _type;
        private int _healths;
        private int _defense;
        private int _strength;
        private int _dexterity;
        private int _skill;

		public Player(string name, int type)
		{
			_name = name;
			_type = type;

			Dictionary<string, int> inform = _getter.GetPlayerParametrs(type);

			_healths = inform["_healths"];
            _defense = inform["_defense"];
            _strength = inform["_strength"];
            _dexterity = inform["_dexterity"];
            _skill = inform["_skill"];
        }
	}
}
