using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals_FinalAssignment
{
    public class Fight
    {
        // fields
        private HashSet<Monster> monstersDefeated = new HashSet<Monster>();
        public int fightsWon = 0;
        public int fightsLost = 0;

        // properties
        public HashSet<Monster> DefeatedMonsters { get { return monstersDefeated; } }
        public int FightsWon { get { return fightsWon;} }
        public int FightsLost { get {  return fightsLost; } }


        // constructor class 
        public Fight(Hero hero) 
        {
            // create random monsters
            HashSet<Monster> MonsterList = new HashSet<Monster>();
            MonsterList.Add(new Monster("PEKKA", 7, 12, 150));
            MonsterList.Add(new Monster("Electro Dragon", 5, 10, 120));
            MonsterList.Add(new Monster("Lava Hound", 6, 8, 100));
            MonsterList.Add(new Monster("Witch", 4, 3, 90));
            MonsterList.Add(new Monster("Giant", 5, 9, 130));

            // get a random monster 
            Random random = new Random();
            int randomMonster = random.Next(MonsterList.Count);
            Monster monster = MonsterList.ElementAt(randomMonster);

            while (hero.CurrentHealth == 0 || monster.CurrentHealth != 0)
            {
                HeroTurn(hero, monster);
                Console.WriteLine(handleWin(hero, monster, MonsterList));
                Console.WriteLine(handleLose(hero, monster, MonsterList));

                MonsterTurn(hero, monster);
                Console.WriteLine(handleWin(hero, monster, MonsterList));
                Console.WriteLine(handleLose(hero, monster, MonsterList));
            }
        }


        // method for the hero's turn
        public int HeroTurn(Hero hero, Monster monster)
        {
            int heroAttack = hero.BaseStrength + hero.heroWeaponPower;
            int damageToMonster = heroAttack - monster.Defence;

            monster.setCurrentHealth(damageToMonster);
            int monsterCurrentHealth = monster.CurrentHealth;

            // get the remaining monster health in percentage
            int division = (monsterCurrentHealth / monster.OriginalHealth) * 100;
            

            Console.WriteLine("\nHero attacked the moster!");
            Console.WriteLine($"Damage: {damageToMonster}  |  Monster's Health: {division} %");

            return monsterCurrentHealth;
        }

        // method for the monster's turn
        public int MonsterTurn(Hero hero, Monster monster)
        {
            int monsterAttack = monster.Strength;
            int damageToHero = (hero.BaseDefence + hero.heroArmourPower) - monsterAttack;

            hero.setCurrentHealth(damageToHero);
            int heroCurrentHealth = hero.CurrentHealth;

            // get the remaining hero health in percentage
            int division = (heroCurrentHealth / hero.OriginalHealth) * 100;

            Console.WriteLine("\nMonster attacked The Hero!");
            Console.WriteLine($"Damage: {damageToHero}  |  Hero's Health: {division}");

            return heroCurrentHealth;
        }

        public string handleWin(Hero hero, Monster monster, HashSet<Monster> monsterList)
        {
            string winStatement = "";
            if (monster.CurrentHealth == 0)
            {
                winStatement = $"\n\nGame Over!!\n~ You have defeated the {monster.Name} ~\nCongratulations {hero.Name}! (^_^) ";
                monsterList.Remove(monster);
                DefeatedMonsters.Add(monster);
                hero.CurrentHealth = hero.OriginalHealth;
                fightsWon++;
            }

            return winStatement;
        }

        public string handleLose(Hero hero, Monster monster, HashSet<Monster> monsterList)
        {
            string loseStatement = "";
            if (hero.CurrentHealth == 0)
            {
                fightsLost++;
                loseStatement = $"\n\nGame Over!!\n You have been defeated by {monster.Name}!\nBetter luck next time.";
            }

            if (DefeatedMonsters != null)
            {
                for (int i = 0; i < DefeatedMonsters.Count; i++)
                {
                    monsterList.Add(monster);
                }
            }

            return loseStatement;
        }
    }
}
