using System;
using System.Collections.Generic;
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
            Name = "";
            Type = EnemyType(randomFight);
            (Strength, Health) = GenerateEnemy(Type);
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
                    minHealth = 3;
                    maxHealth = 10;
                    Health = Randomizer(minHealth, maxHealth);
                    minStrength = 1;
                    maxStrength = 3;
                    Strength = Randomizer(minStrength, maxStrength);
                    break;
                case "Goblin":
                    minHealth = 3;
                    maxHealth = 3;
                    Health = Randomizer(minHealth, maxHealth);
                    minStrength = 1;
                    maxStrength = 1;
                    Strength = Randomizer(minStrength, maxStrength);
                    break;
                case "Orc":
                    minHealth = 5;
                    maxHealth = 15;
                    Health = Randomizer(minHealth, maxHealth);
                    minStrength = 3;
                    maxStrength = 3;
                    Strength = Randomizer(minStrength, maxStrength);
                    break;
                case "Cheiftan":
                    minHealth = 10;
                    maxHealth = 20;
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
            var min = 0;
            var max = 0;
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
    }
}
