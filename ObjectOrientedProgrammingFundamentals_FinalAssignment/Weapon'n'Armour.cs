using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals_FinalAssignment
{
    abstract class Weapon_n_Armour
    {
        // fields
        private string _Name;
        private int _Power;

        // properties
        public string Name { get { return _Name; } }
        public int Power { get { return _Power; } }

        //  setting the name
        public void SetName(string name)
        {
            _Name = name;
        }
        // setting the power
        public void SetPower(int power)
        {
            _Power = power;
        }
    }

    class Weapon : Weapon_n_Armour
    {
        public Weapon(string weaponName, int weaponPower)
        {
            SetName(weaponName);
            SetPower(weaponPower);
        }
    }

    class Armour : Weapon_n_Armour
    {
        public Armour(string armourName, int armourPower)
        {
            SetName(armourName);
            SetPower(armourPower);
        }
    }
}
