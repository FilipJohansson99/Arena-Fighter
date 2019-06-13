using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    class Graphics
    {
        public static void DrawStats(Character player)
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
        }
    }
}