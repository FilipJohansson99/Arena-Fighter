using System;
using System.Text;

namespace Arena_Fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool retired = false;
            var day = 1;

            Character player = new Character();
            Gameplay game = new Gameplay();
            StringBuilder combatLog = new StringBuilder();

            while (!retired && player.Health > 0)
            {
                Console.Clear();
                Graphics.DrawStats(player);

                game.Events(player, combatLog, day);

                Console.WriteLine("\n\tPress any key to progress to the next day...");
                Console.ReadKey();

                day++;
            } 

            Console.Clear();

            Console.WriteLine(combatLog);

            Console.ReadKey();
        }           
    }
}
