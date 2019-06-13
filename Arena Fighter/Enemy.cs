using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Arena_Fighter
{
    class Enemy
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Strength { get; private set; }
        public int Health { get; set; }

        public Enemy(int randomFight)
        {            
            Name = RandomizeName();
            Type = EnemyType(randomFight);
            (Strength, Health) = GenerateEnemy(Type);
        }
        public void DrawEnemyStats()
        {
            StringBuilder enemy = new StringBuilder();
            enemy.AppendLine("Name: " + Name);
            enemy.AppendLine("Type: " + Type);
            enemy.AppendLine("Strength: " + Strength.ToString());
            enemy.AppendLine("Health: " + Health.ToString());
            Console.WriteLine(enemy);
        }
        private (int, int) GenerateEnemy(string Type)
        {
            var minHealth = 0;
            var maxHealth = 0;
            var minStrength = 0;
            var maxStrength = 0;

            switch (Type)
            {
                case "Human":
                    minHealth = 5;
                    maxHealth = 15;
                    Health = Randomizer(minHealth, maxHealth);
                    minStrength = 1;
                    maxStrength = 3;
                    Strength = Randomizer(minStrength, maxStrength);
                    break;
                case "Goblin":
                    minHealth = 3;
                    maxHealth = 10;
                    Health = Randomizer(minHealth, maxHealth);
                    minStrength = 1;
                    maxStrength = 1;
                    Strength = Randomizer(minStrength, maxStrength);
                    break;
                case "Orc":
                    minHealth = 10;
                    maxHealth = 20;
                    Health = Randomizer(minHealth, maxHealth);
                    minStrength = 3;
                    maxStrength = 5;
                    Strength = Randomizer(minStrength, maxStrength);
                    break;
                case "Cheiftan":
                    minHealth = 15;
                    maxHealth = 30;
                    Health = Randomizer(minHealth, maxHealth);
                    minStrength = 3;
                    maxStrength = 5;
                    Strength = Randomizer(minStrength, maxStrength);
                    break;
            }
            return (Strength, Health);
        }
        private string EnemyType(int randomFight)
        {
            var type = "";

            switch (randomFight)
            {
                case 1:
                    type = "Human";
                    break;
                case 2:
                    type = "Goblin";
                    break;
                case 3:
                    type = "Orc";
                    break;
                case 4:
                    type = "Cheiftan";
                    break;
                default:
                    break;
            }

            return type;
        }
        public int Randomizer(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string RandomizeName()
        {
            InfoGenerator randomEnemy = new InfoGenerator(DateTime.Now.Millisecond);
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            var enemyName = randomEnemy.NextFullName();
            var name = textInfo.ToTitleCase(enemyName);

            return name;
        }

    }
}
