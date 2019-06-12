using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    public class Gameplay
    {
        public int Randomizer(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public (int, int, int, int) Events(Character player, StringBuilder combatLog, int day)
        {
            var min = 1;
            var max = 11;
            var randomEvent = Randomizer(min, max);
            var eventTitle = "";
            var consequence = "";

            switch (randomEvent)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    eventTitle = "Duel";
                    consequence = "";
                        //EventBattle();
                    break;
                case 7:
                    eventTitle = "You fell over...";
                    consequence = "You took 1 health worth of damage.";
                    player.Health--;
                    break;
                case 8:
                    eventTitle = "Travelling Merchant";
                    consequence = EventMerchant(player);
                    break;
                case 9:
                    eventTitle = "Tavern";                        
                    consequence = EventTavern(player);
                    break;
                case 10:
                    min = 5;
                    max = 40;
                    var treasure = Randomizer(min, max);
                    eventTitle = "Tresure";
                    player.Gold += treasure;
                    consequence = $"You found {treasure} gold.";
                    break;
                default:
                    break;

            }
            Console.WriteLine($"Day: {day} - {eventTitle}\n");
            Console.WriteLine($"\t{consequence}");

            combatLog.AppendLine($"Day: {day} - {eventTitle}\n");
            combatLog.AppendLine($"\t{consequence}");

            return (player.Health, player.Strength, player.Defence, player.Gold);
        }

        public void EventBattle()
        {
            var min = 1;
            var max = 4;
            var randomFight = Randomizer(min, max);
            StringBuilder combatLog = new StringBuilder();

            Enemy enemy = new Enemy(randomFight);

        }

        public string EventTavern(Character player)
        {
            bool validSelection = true;
            var consequence = "";
            do
            {
                validSelection = true;
                Console.WriteLine("You come across a tavern, do you want to spend 10 gold to stay the night?");
                Console.WriteLine("Y - Yes\nN - No");
                var op = Console.ReadLine().ToUpper();
                switch (op)
                {
                    case "Y":
                        if (player.Gold < 10)
                        {                          
                            consequence = ("You cannot afford to stay at the tavern.");
                        }
                        else
                        {
                            player.Gold -= 10;
                            player.Health = 10;
                            consequence = ("You get a good nights rest, health restored.");
                        }
                        break;
                    case "N":
                        consequence = ("You decide not to stay at the tavern.");
                        break;
                    default:
                        validSelection = false;
                        break;
                }
            } while (!validSelection);
            Console.WriteLine(consequence);
            return consequence;
        }
        public string EventMerchant(Character player)
        {
            bool validSelection = true;
            var consequence = "";
            var min = 1;
            var max = 4;
            var randomItem = Randomizer(min, max);
            var item = "";
            var price = 0;
            switch (randomItem)
            {
                case 1:
                    item = "Better Armor";
                    price = 40;
                    break;
                case 2:
                    item = "Health Potion";
                    price = 20;
                    break;
                case 3:
                    item = "Upgraded Weapon";
                    price = 50;
                    break;
            }
            do
            {
                validSelection = true;
                Console.WriteLine($"You come across a merchant who wants to sell you a {item} for {price} gold");
                Console.WriteLine("Y - Yes\nN - No");
                var op = Console.ReadLine().ToUpper();
                switch (op)
                {
                    case "Y":
                        if (player.Gold < price)
                        {
                            consequence = ($"You couldn't afford the {item}");
                        }
                        else
                        {
                            player.Gold -= price;
                            consequence = ($"You purchased the {item}");
                            if (item == "Better Armor")
                                player.Armor++;
                            else if (item == "Health Potion")
                                player.HealthPotions++;
                            else if (item == "Upgraded Weapon")
                                player.Damage++;
                        }
                        break;
                    case "N":
                        consequence = ("You decided not to purchase anything");
                        break;
                    default:
                        validSelection = false;
                        break;
                }
            } while (!validSelection);
            Console.WriteLine(consequence);
            return consequence;

        }

    }

}
