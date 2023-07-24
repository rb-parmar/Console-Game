using ObjectOrientedProgrammingFundamentals_FinalAssignment;
using System.Xml;

class Program
{
    static void Main()
    {
        // opt user for name
        Console.WriteLine("Please enter your name:");
        string playerName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(playerName)) 
        {
            Console.WriteLine("Please enter a valid name");
            playerName = Console.ReadLine();
        }

        // initiate a new hero
        Hero hero = new Hero(playerName, 5, 3, 100);

        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu(hero);

        }
    }

    // displaying main menu
    public static bool MainMenu(Hero hero)
    {

        // display main 
        Console.WriteLine("\n~ Main Menu ~");
        Console.WriteLine(" 1. Display statistics.");
        Console.WriteLine(" 2. Display inventory.");
        Console.WriteLine(" 3. Fight.");
        Console.WriteLine(" 4. Exit.");
        Console.WriteLine("\nPlease select from the options above.\n");

        bool runOption = true;
        char option = char.Parse(Console.ReadLine());
        while (runOption)
        {
            if (char.IsNumber(option))
            {
                runOption = false;
            }
        }

        int gamesPlayed = 0;

        bool toggle = true;

        switch (Int32.Parse(option.ToString()))
        {
            case 1:
                displayStatistics(hero, gamesPlayed);
                toggle = false;
                break;
            case 2:
                displayInventory(hero);
                break;
            case 3:
                gamesPlayed += 1;
                handleNewFight(hero);
                toggle = false;
                break;
            case 4:
                toggle = false;
                break;
        }

        return toggle;
    }

    // handling option 1
    public static void displayStatistics(Hero hero, int gamesPlayed)
    {
        Console.WriteLine("~ Stats ~");
        Console.WriteLine($"Number of games played: {gamesPlayed}\n");
        hero.GetHeroStats();
        MainMenu(hero);
    }

    // handling option 2
    public static void displayInventory(Hero hero)
    {
        Console.WriteLine("Choose from the following options: ");
        Console.WriteLine(" 1. Change equipped weapon.");
        Console.WriteLine(" 2. Change equipped armour.");
        Console.WriteLine(" 3. Exit to main menu.");

        bool runOption = true;
        char option = char.Parse(Console.ReadLine());
        while (runOption)
        {
            if (char.IsNumber(option))
            {
                runOption = false;
            }
        }

        switch (Int32.Parse(option.ToString()))
        {
            case 1:
                displayInventoryOption1(hero);
                break;
            case 2:
                displayInventoryOption2(hero);
                break;
            case 3:
                Main();
                break;
        }
    }

    // handling option 2 -> 1
    public static void displayInventoryOption1(Hero hero)
    {
        Console.WriteLine("Choose from the weapons below:");
        Console.WriteLine(" 1. Weapon: Sword  Power: 6");
        Console.WriteLine(" 2. Weapon: Laser gun  Power: 9");
        Console.WriteLine(" 3. Weapon: Life saber  Power: 12");

        bool runOption = true;
        char option = char.Parse(Console.ReadLine());
        while (runOption)
        {
            if (char.IsNumber(option))
            {
                runOption = false;
            }
        }

        switch (Int32.Parse(option.ToString()))
        {
            case 1:
                hero.EquipWeaponOrArmour("Sword", 6, true);
                break;
            case 2:
                hero.EquipWeaponOrArmour("Laser gun", 9, true);
                break;
            case 3:
                hero.EquipWeaponOrArmour("Life saber", 12, true);
                break;
        }

        MainMenu(hero);
    }

    // handling option 2 -> 2
    public static void displayInventoryOption2(Hero hero)
    {
        Console.WriteLine("Choose from the armours below:");
        Console.WriteLine(" 1. Armour: Steel shield  Power: 5");
        Console.WriteLine(" 2. Armour: Breastplate  Power: 3");
        Console.WriteLine(" 3. Armour: Studded leather  Power: 7");

        bool runOption = true;
        char option = char.Parse(Console.ReadLine());
        while (runOption)
        {
            if (char.IsNumber(option))
            {
                runOption = false;
            }
        }

        switch (Int32.Parse(option.ToString()))
        {
            case 1:
                hero.EquipWeaponOrArmour("Steel shield", 5, false);
                break;
            case 2:
                hero.EquipWeaponOrArmour("Breastplate", 3, false);
                break;
            case 3:
                hero.EquipWeaponOrArmour("Studded leather", 7, false);
                break;
        }

        MainMenu(hero);
    }

    // handling option 3
    public static void handleNewFight(Hero hero)
    {
        HashSet<Weapon> weapons = new HashSet<Weapon>();
        weapons.Add(new Weapon("Life saber", 12));
        weapons.Add(new Weapon("Laser gun", 9));
        weapons.Add(new Weapon("Sword", 6));

        Random random = new Random();
        int index = random.Next(0, weapons.Count);
        Weapon equipWeapon = weapons.ElementAt(index);

        if (hero.GetWeapon == null)
        {
            hero.EquipWeaponOrArmour(equipWeapon.Name, equipWeapon.Power, true);
        }

        HashSet<Armour> armours = new HashSet<Armour>();
        armours.Add(new Armour("Shield", 5));
        armours.Add(new Armour("Breastplate", 3));
        armours.Add(new Armour("Studded leather", 7));

        Random random1 = new Random();
        int indexArmour = random1.Next(0, armours.Count);
        Armour equipArmour = armours.ElementAt(indexArmour);

        if (hero.GetArmour == null)
        {
            hero.EquipWeaponOrArmour(equipArmour.Name, equipArmour.Power, false);
        }

        Fight newFight = new Fight(hero);
        

    }

}