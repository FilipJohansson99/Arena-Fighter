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
                (Strength, Health, Defence) = CreateCharacterStats(Strength, Health, Defence);
            else
                (Strength, Health, Defence) = GenerateCharacterStats(Strength, Health, Defence, ClassName);

            (Damage, Armor, HealthPotions, Gold) = GenerateCharacterEquipment(Damage, Armor, HealthPotions, Gold, ClassName);

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
                    if (Name.Length > 15 || String.IsNullOrWhiteSpace(Name))
                        validName = false;
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
                    Console.WriteLine("1 - Warrior\n2 - Mage\n3 - Scout\n4 - Thief\n5 - Custom");
                    Console.Write("Select your preferred class: ");
                    op = Console.ReadLine().ToUpper();
                    switch (op)
                    {
                        case "1":
                        case "WARRIOR":
                            ClassName = "Warrior";
                            Console.WriteLine("Warrior info:");
                            break;
                        case "2":
                        case "MAGE":
                            ClassName = "Mage";
                            Console.WriteLine("Mage info:");
                            break;
                        case "3":
                        case "SCOUT":
                            ClassName = "Scout";
                            Console.WriteLine("Scout info:");
                            break;
                        case "4":
                        case "THIEF":
                            ClassName = "Thief";
                            Console.WriteLine("Thief info:");
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
        private (int, int, int) GenerateCharacterStats(int Strength, int Health, int Defence, string Class)
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
                    Defence = 2;
                    break;
            }

            return (Strength, Health, Defence);
        }
        private (int, int, int, int) GenerateCharacterEquipment(int Damage, int Armor, int HealthPotions, int Gold, string Class)
        {
            switch (ClassName)
            {
                case "Warrior":
                    Armor = 2;
                    break;
                case "Mage":
                    HealthPotions = 1;
                    break;
                case "Scout":
                    Damage = 2;
                    break;
                case "Thief":
                    break;
                case "Custom":
                    Gold = 50;
                    break;
            }
            return (Damage, Armor, HealthPotions, Gold);
        }
        private (int, int, int) CreateCharacterStats(int Strength, int Health, int Defence)
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

            return (Strength, Health, Defence);
        }
    }
}

