using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals_FinalAssignment
{
    abstract class Weapon_n_Armour
    {
        private string _name;
        private int _power;

        public string Name() { return _name; }
        public int Power() { return _power; }

        public void SetName(string name)
        {
            if (name.Length > 0)
            {
                _name = name;
            }
        }
        public void SetPower(int power)
        {
            if (power.Length > 0)
            {
                _power = power;
            }

        }
    }

    class Weapon : Weapon_n_Armour
    {
        public Weapon(string weaponName, int weaponPower)
        {
            Weapon_n_Armour.SetName(weaponName);
            Weapon_n_Armour.SetPower(weaponPower);
        }
    }

    class Armour : Weapon_n_Armour
    {
        public Armour(string armourName, int armourPower)
        {
            Weapon_n_Armour.SetName(armourName);
            Weapon_n_Armour.SetPower(armourPower);
        }
    }
}
