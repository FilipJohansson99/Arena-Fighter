using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    public class Arena
    {
        public void Fighter(int day, string weekday)
        {
            

            Time time = new Time();

            day++;
            time.Weekday(day);
            time.DisplayDay(day, weekday);

            if (weekday != "Saturday" && weekday != "Sunday")
            {
                //Duel
            }
            else
            {
                //Town
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();

        }

    }
}
