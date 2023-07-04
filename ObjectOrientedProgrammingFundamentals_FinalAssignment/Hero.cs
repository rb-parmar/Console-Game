using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        private Weapon _EquippedWeapon;
        private Armour _EquippedArmour;

        // Properties:
        public string Name { get { return _Name; } }
        public int BaseStrength { get { return _BaseStrength; } }
        public int BaseDefence { get { return _BaseDefence; } }
        public int OriginalHealth { get { return _OriginalHealth; } }
        public int CurrentHealth { 
            get { return _CurrentHealth; }
            set { _CurrentHealth = value; }
        }
        public string heroWeaponName { get { return _EquippedWeapon.Name; } }
        public int heroWeaponPower { get { return _EquippedWeapon.Power; } }
        public string heroArmourName { get { return _EquippedArmour.Name; } }
        public int heroArmourPower { get { return _EquippedArmour.Power; } }

        public void setCurrentHealth(int damage)
        {
            if (CurrentHealth > damage && damage > 0)
            {
                CurrentHealth -= damage;
            }
            else
            {
                CurrentHealth = 0;
            }
        }

        // Constructor for class Hero
        public Hero(
            string heroName, int baseStrength, int baseDefence, 
            int originalHealth)
        {
            // validating hero name
            if (heroName.Length <= 0)
            {
                Console.WriteLine("Hero name cannot be empty.");
            } else
            {
                _Name = heroName;
            }

            // validating base strength
            if (baseStrength <= 0)
            {
                Console.WriteLine("Base strenght cannot be less than 0.");
            } else
            {
                _BaseStrength = baseStrength;
            }

            // validating base defence
            if (baseDefence <= 0)
            {
                Console.WriteLine("Base defence cannot be less than 0.");
            }
            else
            {
                _BaseDefence = baseDefence;
            }

            // validating original health
            if (originalHealth <= 0)
            {
                Console.WriteLine("Original health cannot be below 0.");
            } else
            {
                _OriginalHealth = originalHealth;
            }

            // intial current health will be the same as original health
            _CurrentHealth = originalHealth;
        }
        

       
        
        public void GetHeroStats()
        {
            Console.WriteLine(" ~ Hero statistics ~ ");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Base strength: {BaseStrength}");
            Console.WriteLine($"Base defence: {BaseDefence}");
            Console.WriteLine($"Hero's original health: {OriginalHealth}");
            Console.WriteLine($"Hero's current health: {CurrentHealth}");
            
        }

        // method to get the items the hero is equipped with
        public void GetInventory()
        {
            Console.WriteLine("The hero is equipped with: ");
            Console.WriteLine($" 1. Weapon: {heroWeaponName}, Power: {heroWeaponPower}");
            Console.WriteLine($" 2. Armour: {heroArmourName}, Power: {heroArmourPower}");
        }

        // method for equipping a new weapon or armour
        public void EquipWeaponOrArmour(string  itemName, int itemPower, bool determiner)
        {
            if (string.IsNullOrWhiteSpace(itemName) || itemName.Length < 0)
            {
                Console.WriteLine("\nWeapon name provided cannot be empty.");
            }
            else if (itemPower <= 0)
            {
                Console.WriteLine("\nWeapon power should be more than 0.");
            } 
            else if (determiner) // if true
            {
                _EquippedWeapon = new Weapon(itemName, itemPower);
            } else
            {
                _EquippedArmour = new Armour(itemName, itemPower);
            }
        }

    
    }
}
