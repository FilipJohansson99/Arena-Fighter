using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    public class Character
    {






        public static string CreateCharacterName(string characterName)
        {
            bool areYouSure = false;
            bool validName = true;
            do
            {
                do
                {
                    Console.Clear();
                    Console.Write("Enter the name of your character: ");
                    characterName = Console.ReadLine();
                    if (characterName.Length > 15 || String.IsNullOrWhiteSpace(characterName))
                        validName = false;
                    //else if CHARACTER WHITELIST
                } while (!validName);
                Console.WriteLine("Are you sure you want to be called {0}?", characterName);
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

            return characterName;
        }
        public static string CreateCharacterClass(string characterClass)
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
                            characterClass = "Warrior";
                            Console.WriteLine("Warrior info:");
                            break;
                        case "2":
                        case "MAGE":
                            characterClass = "Mage";
                            Console.WriteLine("Mage info:");
                            break;
                        case "3":
                        case "SCOUT":
                            characterClass = "Scout";
                            Console.WriteLine("Scout info:");
                            break;
                        case "4":
                        case "THIEF":
                            characterClass = "Thief";
                            Console.WriteLine("Thief info:");
                            break;
                        case "5":
                        case "CUSTOM":
                            characterClass = "Custom";
                            Console.WriteLine("Custom info:");
                            break;
                        default:
                            validSelection = false;
                            break;
                    }
                } while (!validSelection);
                Console.WriteLine("Are you sure you want to be a {0}-class?", characterClass);
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

            return characterClass;
        }
        public static (int, int, int) GenerateCharacterStats(int characterStrength, int characterHealth, int characterDefence, string characterClass)
        {
            switch (characterClass)
            {
                case "Warrior":
                    characterStrength = 5;
                    characterHealth = 5;
                    break;
                case "Mage":
                    characterStrength = 3;
                    characterHealth = 3;
                    characterDefence = 2;
                    //healthPotion = 1;
                    break;
            }

            return (characterStrength, characterHealth, characterDefence);
        }
        public static void GenerateCharacterEquipment(string characterClass)
        {
            switch (characterClass)
            {
                case "Warrior":
                    //swordLevel = 1;
                    break;
                case "Mage":
                    //healthPotion = 1;
                    break;
                case "Custom":
                    //gold = 50;
                    break;
            }
        }
        public static (int, int, int, int) CreateCharacterStats(int characterStrength, int characterHealth, int characterDefence, int skillPoints)
        {
            for (int i = skillPoints; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine("Strength: " + characterStrength + "\nHealth: " + characterHealth + "\nDefence: " + characterDefence + "\nSkillpoints Remaining: " + skillPoints);
                Console.WriteLine("1 - Strength\n2 - Health\n3 - Defence");
                Console.Write("Allocate skillpoints to your preferred skill: ");
                var op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        characterStrength += 1;
                        break;
                    case "2":
                        characterHealth += 1;
                        break;
                    case "3":
                        characterDefence += 1;
                        break;
                    default:
                        break;
                }
                skillPoints -= 1;
            }

            return (characterStrength, characterHealth, characterDefence, skillPoints);
        }
    }
}
