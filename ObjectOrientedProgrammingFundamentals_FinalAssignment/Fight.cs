using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals_FinalAssignment
{
    public class Fight
    {

        // method for the hero's turn
        public int HeroTurn(Hero hero, Monster monster)
        {
            int heroAttack = hero.BaseStrength + hero.heroWeaponPower;
            int damageToMonster = heroAttack - monster.Defence;

            int monsterCurrentHealth = monster.setCurrentHealth(damageToMonster);

            return monsterCurrentHealth;
        }

        // method for the monster's turn
        public int MonsterTurn(Hero hero, Monster monster)
        {
            int monsterAttack = monster.Strength;
            int damageToHero = (hero.BaseDefence + hero.heroArmourPower ) - monsterAttack;

            int heroCurrentHealth = hero.setCurrentHealth(damageToHero);

            return heroCurrentHealth;
        }


    }
}
