using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals_FinalAssignment
{
    public class Monster
    {
        // fields
        private string _Name;
        private int _Strength;
        private int _Defence;
        private int _OriginalHealth;
        private int _CurrentHealth;

        // properties:
        public string Name { get { return _Name; } }
        public int Strength { get { return _Strength; } }
        public int Defence { get { return _Defence; } }
        public int OriginalHealth { get { return _OriginalHealth; } }
        public int CurrentHealth { get { return _CurrentHealth; } }

        // constructor for class Monster
        public Monster(
            string name, int strength, int defence, 
            int originalHealth)
        {
            // validating hero name
            if (name.Length <= 0)
            {
                Console.WriteLine("Hero name cannot be empty.");
            }
            else
            {
                _Name = name;
            }

            // validating base strength
            if (strength <= 0)
            {
                Console.WriteLine("Base strenght cannot be less than 0.");
            }
            else
            {
                _Strength = strength;
            }

            // validating base defence
            if (defence <= 0)
            {
                Console.WriteLine("Base defence cannot be less than 0.");
            }
            else
            {
                _Defence = defence;
            }

            // validating original health
            if (originalHealth <= 0)
            {
                Console.WriteLine("Original health cannot be below 0.");
            }
            else
            {
                _OriginalHealth = originalHealth;
            }

            // intial current health will be the same as original health
            _CurrentHealth = originalHealth;
        }
    }
}
