using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    public class Time
    {
        public void DisplayDay(int day, string weekday)
        {
            Console.WriteLine($"Day: {day}, {weekday}");
        }
        public string Weekday(int day)
        {
            var weekday = "";
            switch (day)
            {
                case 1:
                    weekday = "Monday";
                    break;
                case 2:
                    weekday = "Thuesday";
                    break;
                case 3:
                    weekday = "Wednsday";
                    break;
                case 4:
                    weekday = "Thursday";
                    break;
                case 5:
                    weekday = "Friday";
                    break;
                case 6:
                    weekday = "Saturday";
                    break;
                case 7:
                    weekday = "Sunday";
                    break;
                default:
                    break;
            }
            return weekday;
        }
    }
}
