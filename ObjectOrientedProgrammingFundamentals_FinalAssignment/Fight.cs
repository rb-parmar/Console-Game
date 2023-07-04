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
            MonsterList.Add(new Monster("PEKKA", 20, 4, 100));
            MonsterList.Add(new Monster("Electro Dragon", 17, 5, 100));
            MonsterList.Add(new Monster("Lava Hound", 15, 5, 100));
            MonsterList.Add(new Monster("Witch", 10, 2, 100));
            MonsterList.Add(new Monster("Giant", 9, 5, 100));

            // get a random monster 
            Random random = new Random();
            int randomMonster = random.Next(MonsterList.Count);
            Monster monster = MonsterList.ElementAt(randomMonster);

            bool isGameOver = false;
            while (!isGameOver)
            {
                if (monster.CurrentHealth > 0 && hero.CurrentHealth > 0)
                {
                    HeroTurn(hero, monster);
                    Console.WriteLine(handleWin(hero, monster, MonsterList));
                    Console.WriteLine(handleLose(hero, monster, MonsterList));
                } else
                {
                    isGameOver = true;
                }

                if (hero.CurrentHealth > 0 && monster.CurrentHealth > 0)
                {
                    MonsterTurn(hero, monster);
                    Console.WriteLine(handleWin(hero, monster, MonsterList));
                    Console.WriteLine(handleLose(hero, monster, MonsterList));
                } else
                {
                    isGameOver = true;
                }

            }

            Program.MainMenu(hero);
          
        }


        // method for the hero's turn
        public void HeroTurn(Hero hero, Monster monster)
        {
            int heroAttack = hero.BaseStrength + hero.heroWeaponPower;
            int damageToMonster = heroAttack - monster.Defence;

            monster.setCurrentHealth(damageToMonster);
            
            Console.WriteLine("\nHero attacked the moster!");
            Console.WriteLine($"Damage: {damageToMonster}  |  Monster's Health: {monster.CurrentHealth} %");

        }

        // method for the monster's turn
        public void MonsterTurn(Hero hero, Monster monster)
        {
            int monsterAttack = monster.Strength;
            int damageToHero = monsterAttack - hero.BaseDefence - hero.heroArmourPower;

            hero.setCurrentHealth(damageToHero);

            Console.WriteLine("\nMonster attacked The Hero!");
            Console.WriteLine($"Damage: {damageToHero}  |  Hero's Health: {hero.CurrentHealth}%");

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
