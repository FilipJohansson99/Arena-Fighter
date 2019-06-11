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
            var characterDefence = 0;
            var characterDamage = 1;
            var skillPoints = 10;
            var gold = 0;

            characterName = Character.CreateCharacterName(characterName);
            characterClass = Character.CreateCharacterClass(characterClass);

            if (characterClass == "Custom")
                (characterStrength, characterHealth, characterDefence, skillPoints)
                    = Character.CreateCharacterStats(characterStrength, characterHealth, characterDefence, skillPoints);
            else
                (characterStrength, characterHealth, characterDefence) 
                    = Character.GenerateCharacterStats(characterStrength, characterHealth, characterDefence, characterClass);


            //DrawHUD()
            Console.WriteLine(characterClass + " " + characterName);
            Console.WriteLine("Character Strength: " + characterStrength);
            Console.WriteLine("Character Health: " + characterHealth);
            Console.WriteLine("Armor Level: " + characterDefence);
            Console.WriteLine("Weaponry Level: " + characterDamage);
            Console.WriteLine("Skillpoints: " + skillPoints);
            Console.WriteLine("Gold: " + gold);
            Console.ReadKey();








        }
    }
}
