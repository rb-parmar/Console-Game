using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals_FinalAssignment
{
    public class Hero
    {
        // fields for hero
        private string _Name;
        private int _BaseStrength;
        private int _BaseDefence;
        private int _OriginalHealth;
        private int _CurrentHealth;
        private Weapon_n_Armour EquippedWeapon;
        private Weapon_n_Armour EquippedArmour;

        // Properties:
        public string Name() { return _Name; }
        public int BaseStrength() { return _BaseStrength; }
        public int BaseDefence() { return _BaseDefence; }
        public int OriginalHealth() { return _OriginalHealth; }
        public int CurrentHealth() { return _CurrentHealth; }

        

        // method to get statistics of the hero
        public void GetHeroStats()
        {
            Console.WriteLine(" ~ Hero statistics ~ ");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Base strength: {BaseStrength}");
            Console.WriteLine($"Base defence: {BaseDefence}");
            Console.Writeline($"Hero's original health: {OriginalHealth}");
            Console.WriteLine($"Hero's current health: {CurrentHealth}");
        }

        // method to get the itams the hero is equipped with
        public void GetInventory()
        {
            Console.WriteLine("The hero is equipped with: ");
            Console.Writeline($" 1. Weapon: {EquippedWeapon.Name}, Power: {EquippedWeapon.Power}");
            Console.WriteLine($" 2. Armour: {EquippedArmour.Name}, Power: {EquippedArmour.Power}");
        }

        // method for equipping a new weapon
        public void EquipWeapon(string  weaponName, int weaponPower)
        {
            EquippedWeapon = new Weapon(weaponName, weaponPower);
        }

        // method for equipping a new armour
        public void EquipWeapon(string armourName, int armourPower)
        {
            EquippedWeapon = new Armour(armourName, armourPower);
        }
    }
}
