using System;
using System.Text;

namespace Arena_Fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Gameplay game = new Gameplay();
            var seed = game.GenerateSeed();
            game.Town(seed);
            Console.ReadKey();








            /*
            bool retired = false;
            var day = 1;

            Character player = new Character();
            Gameplay game = new Gameplay();
            StringBuilder combatLog = new StringBuilder();
            combatLog.AppendLine("\nGAME LOG:\n");
            combatLog.AppendLine("Your Character: \n");
            combatLog.AppendLine(Character.DrawStats(player).ToString());
            combatLog.AppendLine("\n GAME START:");

            while (!retired && player.Health > 0)
            {
                Console.Clear();
                Character.DrawStats(player);
                retired = game.Morning(day, player, combatLog);

                if (retired)
                {
                    Console.WriteLine("You retired...");
                    combatLog.AppendLine("\n\tYou retired.");
                    Console.ReadKey();
                    break;
                }
                else if (player.Health <= 0)
                {
                    combatLog.AppendLine("\n\tYou died");
                    Console.WriteLine("You died...");
                    Console.ReadKey();
                }
                else if (player.Health > 0 && !retired)
                {
                    Console.WriteLine("\n\tPress any key to progress to the next day...");
                    Console.ReadKey();
                    day++;
                }
            }
            Console.Clear();

            Console.WriteLine(combatLog);

            Console.ReadKey();
            */
        }
    }
}
