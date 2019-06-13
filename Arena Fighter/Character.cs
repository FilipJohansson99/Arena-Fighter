using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    public class Character
    {
        public string Name { get; private set; }
        public string ClassName { get; private set; }
        public int Strength { get; private set; }
        public int Health { get; set; }
        public int Defence { get; private set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int SkillPoints { get; private set; }
        public int HealthPotions { get; set; }
        public int Gold { get; set; }
        public Character()
        {

            Name = CreateCharacterName(Name);

            ClassName = CreateCharacterClass(ClassName);

            if (ClassName == "Custom")
                CreateCharacterStats();
            else
                GenerateCharacterStats();

            Damage = 1;

            Armor = 1;

            GenerateCharacterEquipment();

            SkillPoints = 0; ;
        }
        private string CreateCharacterName(string Name)
        {
            bool areYouSure = false;
            bool validName = true;
            do
            {
                do
                {
                    validName = true;
                    Console.Clear();
                    Console.Write("Enter the name of your character: ");
                    Name = Console.ReadLine();
                    if (Name.Length > 20 || String.IsNullOrWhiteSpace(Name))
                    {
                        validName = false;
                        Console.WriteLine("The name can't be longer than 20 characters, or contain only empty characters.");
                        Console.ReadKey();
                    }
                    //else if CHARACTER WHITELIST
                } while (!validName);
                Console.WriteLine("Are you sure you want to be called {0}?", Name);
                Console.WriteLine("Y - Yes\nN - No");
                var op = Console.ReadLine().ToUpper();
                switch (op)
                {
                    case "Y":
                        areYouSure = true;
                        break;
                    case "N":
                        break;
                    default:
                        break;
                }
            } while (!areYouSure);

            return Name;
        }
        private string CreateCharacterClass(string ClassName)
        {
            bool areYouSure = false;
            bool validSelection = true;
            var op = "";
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Warrior\n2 - Mage\n3 - Scout\n4 - Thief\n5 - Custom (NOT FINISHED)");
                    Console.Write("Select your preferred class: ");
                    op = Console.ReadLine().ToUpper();
                    switch (op)
                    {
                        case "1":
                        case "WARRIOR":
                            ClassName = "Warrior";
                            Console.WriteLine("Warrior info: The warrior starts with lvl armor. Good for defensive build.");
                            break;
                        case "2":
                        case "MAGE":
                            ClassName = "Mage";
                            Console.WriteLine("Mage info: The mage starts with 1 health potion and a lvl 2 weapon. Good for balanced build.");
                            break;
                        case "3":
                        case "SCOUT":
                            ClassName = "Scout";
                            Console.WriteLine("Scout info: The scout starts with a lvl 2 weapon. Good for aggressive build.");
                            break;
                        case "4":
                        case "THIEF":
                            ClassName = "Thief";
                            Console.WriteLine("Thief info: the thief starts wounded but with 50 gold. Good for high risk build.");
                            break;
                        case "5":
                        case "CUSTOM":
                            ClassName = "Custom";
                            Console.WriteLine("Custom info:");
                            break;
                        default:
                            validSelection = false;
                            break;
                    }
                } while (!validSelection);
                Console.WriteLine("Are you sure you want to be a {0}-class?", ClassName);
                Console.WriteLine("Y - Yes\nN - No");
                op = Console.ReadLine().ToUpper();
                switch (op)
                {
                    case "Y":
                        areYouSure = true;
                        break;
                    case "N":
                        break;
                    default:
                        break;
                }
            } while (!areYouSure);

            return ClassName;
        }
        private void GenerateCharacterStats()
        {
            switch (ClassName)
            {
                case "Warrior":
                    Strength = 5;
                    Health = 10;
                    break;
                case "Mage":
                    Strength = 3;
                    Health = 10;
                    break;
                case "Scout":
                    Strength = 5;
                    Health = 10;
                    break;
                case "Thief":
                    Strength = 3;
                    Health = 5;
                    break;
            }
        }
        private void GenerateCharacterEquipment()
        {
            switch (ClassName)
            {
                case "Warrior":
                    Armor = 3;
                    break;
                case "Mage":
                    HealthPotions = 1;
                    Damage = 2;
                    break;
                case "Scout":
                    Damage = 2;
                    break;
                case "Thief":
                    Gold = 50;
                    break;
                case "Custom":
                    Gold = 50;
                    break;
            }
            //return (Damage, Armor, HealthPotions, Gold);
        }
        private void CreateCharacterStats()
        {
            var skillPoints = 10;
            for (int i = skillPoints; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine("Strength: " + Strength + "\nHealth: " + Health + "\nDefence: " + Defence + "\nSkillpoints Remaining: " + skillPoints);
                Console.WriteLine("1 - Strength\n2 - Health\n3 - Defence");
                Console.Write("Allocate skillpoints to your preferred skill: ");
                var op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        Strength += 1;
                        break;
                    case "2":
                        Health += 1;
                        break;
                    case "3":
                        Defence += 1;
                        break;
                    default:
                        break;
                }
                skillPoints -= 1;
            }
        }
        public static StringBuilder DrawStats(Character player)
        {
            StringBuilder drawStats = new StringBuilder();
            drawStats.AppendLine("");
            drawStats.AppendLine(player.ClassName);
            drawStats.AppendLine("Name: " + player.Name);
            drawStats.AppendLine("");
            drawStats.AppendLine("Strength: " + player.Strength);
            drawStats.AppendLine("Health: " + player.Health);
            drawStats.AppendLine("Weapon Level: " + player.Damage);
            drawStats.AppendLine("Armor Level: " + player.Armor);
            drawStats.AppendLine("");
            drawStats.AppendLine("Gold: " + player.Gold);
            drawStats.AppendLine("Health Potions: " + player.HealthPotions);
            //drawStats.AppendLine("Skill Points: " + player.SkillPoints);
            Console.WriteLine(drawStats);
            return drawStats;
        }
    }
}

