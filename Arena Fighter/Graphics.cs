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
            drawStats.AppendLine(player.ClassName + " " + player.Name);
            drawStats.AppendLine("Strength: " + player.Strength);
            drawStats.AppendLine("Health: " + player.Health);
            drawStats.AppendLine("Defence: " + player.Defence);
            drawStats.AppendLine("Armor: " + player.Armor);
            drawStats.AppendLine("Damage: " + player.Damage);
            drawStats.AppendLine("Health Potions: " + player.HealthPotions);
            drawStats.AppendLine("Gold: " + player.Gold);
            drawStats.AppendLine("Skill Points: " + player.SkillPoints);
            Console.WriteLine(drawStats);
        }
    }
}
