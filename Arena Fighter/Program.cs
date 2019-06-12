using System;

namespace Arena_Fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            var characterName = "";
            var characterClass = "";
            var characterStrength = 0;
            var characterHealth = 0;
            var characterDamage = 0;
            var characterDefence = 0;
            var skillPoints = 10;

            characterName = CreateCharacterName(characterName);
            characterClass = CreateCharacterClass(characterClass);
            (characterStrength, skillPoints) = CreateCharacterStats(skillPoints);
            (characterHealth, skillPoints) = CreateCharacterStats(skillPoints);


            Console.WriteLine("character strength: " + characterStrength);
            Console.WriteLine("character health: " + characterHealth);
            Console.WriteLine("Skillpoints remaining: " + skillPoints);
            Console.ReadKey();








        }
        static string CreateCharacterName(string characterName)
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
        static string CreateCharacterClass(string characterClass)
        {
            bool validSelection = true;
            do
            {
                var op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        characterClass = "Warrior";
                        break;
                    case "2":
                        characterClass = "Mage";
                        break;
                    default:
                        validSelection = false;
                        break;
                }
            } while (!validSelection);
            return characterClass;
        }
        static (int, int) CreateCharacterStats(int skillPoints)
        {
            var stat = 0;

            var op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    skillPoints--; ;
                    stat++;
                    break;
                case "2":
                    skillPoints -= 2;
                    stat += 2;
                    break;
                case "3":
                    skillPoints -= 3;
                    stat += 3;
                    break;
                case "4":
                    skillPoints -= 4;
                    stat += 4;
                    break;
                case "5":
                    skillPoints -= 5;
                    stat += 5;
                    break;
                case "6":
                    skillPoints -= 6;
                    stat += 6;
                    break;
                case "7":
                    skillPoints -= 7;
                    stat += 7;
                    break;
                case "8":
                    skillPoints -= 8;
                    stat += 8;
                    break;
                case "9":
                    skillPoints -= 9;
                    stat += 9;
                    break;
                case "10":
                    skillPoints -= 10;
                    stat += 10;
                    break;
            }




            return (stat, skillPoints);
        }
    }
}
