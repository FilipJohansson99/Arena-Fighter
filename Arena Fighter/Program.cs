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
            StringBuilder combatLog = new StringBuilder();

            while (!retired && player.Health > 0)
            {
                Console.Clear();
                Graphics.DrawStats(player);

                Gameplay game = new Gameplay();
                game.Events(player, combatLog, day);
                Console.ReadKey();


                day++;
            } 
            Console.Clear();
            Console.WriteLine(combatLog);
            Console.ReadKey();
        }           
    }
}
