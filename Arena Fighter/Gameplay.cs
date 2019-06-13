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
            StringBuilder consequence = new StringBuilder();

            Console.WriteLine("--EVENTS--");
            Console.WriteLine($"Day: {day}");
            switch (randomEvent)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    eventTitle = "Duel";
                    consequence.Append(EventBattle(player));

                    break;
                case 7:
                    eventTitle = "You injured yourself";
                    consequence.Append("\tYou took 1 health worth of damage.");
                    player.Health--;
                    break;
                case 8:
                    eventTitle = "Travelling Merchant";
                    consequence.Append(EventMerchant(player));
                    break;
                case 9:
                    eventTitle = "Tavern";
                    consequence.Append(EventTavern(player));
                    break;
                case 10:
                    min = 5;
                    max = 40;
                    var treasure = Randomizer(min, max);
                    eventTitle = "Tresure!";
                    player.Gold += treasure;
                    consequence.Append($"\tYou found {treasure} gold.");
                    break;
                default:
                    break;

            }

            combatLog.AppendLine($"\nDay: {day} - {eventTitle}\n");
            combatLog.AppendLine($"{consequence}");

            return (player.Health, player.Strength, player.Defence, player.Gold);
        }

        public StringBuilder EventBattle(Character player)
        {
            var min = 1;
            var max = 5;
            var randomFight = Randomizer(min, max);
            var diceRoll = 0;
            var damageDealt = 0;
            var isMyTurn = true;
            var statsAreDrawn = false;
            StringBuilder combatLog = new StringBuilder();

            Enemy enemy = new Enemy(randomFight);
           // do
           // {
                do
                {
                    do
                    {
                        if (!statsAreDrawn)
                        {
                            Console.Clear();
                            Graphics.DrawStats(player);
                            Console.WriteLine("\n-----DUEL-----\n");
                            enemy.DrawEnemyStats();
                            statsAreDrawn = true;
                        }
                        if (isMyTurn)
                        {
                            diceRoll = Randomizer(1, 7);
                            damageDealt = diceRoll + player.Strength + player.Damage;
                            enemy.Health -= damageDealt;
                            isMyTurn = false;
                            statsAreDrawn = false;

                            Console.WriteLine("Your turn: ");
                            Console.WriteLine("Press any key to attack...");
                            Console.ReadKey();

                            Console.WriteLine($"You rolled {diceRoll} + Strength: {player.Strength} + Weapon Level: {player.Damage}.\n\tCombined you dealt {damageDealt} damage to {enemy.Name}.\n");
                            combatLog.AppendLine($"\tYou rolled {diceRoll} and dealt {damageDealt} damage to {enemy.Name}.");
                            Console.ReadKey();
                        }
                    } while (!statsAreDrawn);
                    if (enemy.Health <= 0)
                    {
                        var loot = Randomizer(5, 20);
                        player.Gold += loot;

                        Console.WriteLine($"{enemy.Name} was slain.");
                        combatLog.AppendLine($"\n\t{enemy.Name} was slain.");

                        Console.WriteLine($"Scavanging the body you found {loot} gold!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        break;
                    }
                    if (!isMyTurn)
                    {
                        diceRoll = Randomizer(1, 7);
                        damageDealt = diceRoll + enemy.Strength - player.Armor;
                        player.Health -= damageDealt;
                        isMyTurn = true;
                        statsAreDrawn = false;

                        Console.WriteLine($"{enemy.Name}'s turn:");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.WriteLine($"{enemy.Name} rolled {diceRoll} + Strength: {enemy.Strength}. \n\tCombined dealing {damageDealt} damage to you.\n");
                        combatLog.AppendLine($"\t{enemy.Name} rolled {diceRoll} and dealt {damageDealt} damage to you.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                } while (!statsAreDrawn && player.Health > 0);
            //} while (player.Health > 0 && enemy.Health > 0);

            if (player.Health <= 0)
            {
                combatLog.AppendLine("\n\tYou died");
                Console.WriteLine("You died...");
                Console.ReadKey();
            }
            return combatLog;
        }

        public string EventTavern(Character player)
        {
            bool validSelection = true;
            var consequence = "";
            var price = 10;
            do
            {
                validSelection = true;
                Console.WriteLine($"You come across a tavern, do you want to spend {price} gold to stay the night?");
                Console.WriteLine("Y - Yes\nN - No");
                var op = Console.ReadLine().ToUpper();
                switch (op)
                {
                    case "Y":
                        if (player.Gold < price)
                        {
                            consequence = ("\tYou cannot afford to stay at the tavern.");
                        }
                        else
                        {
                            player.Gold -= price;
                            player.Health = 10;
                            consequence = ("\tYou get a good nights rest, health restored.");
                        }
                        break;
                    case "N":
                        consequence = ("\tYou decide not to stay at the tavern.");
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
                            consequence = ($"\tYou couldn't afford the {item}");
                        }
                        else
                        {
                            player.Gold -= price;
                            consequence = ($"\tYou purchased the {item}");
                            if (item == "Better Armor")
                                player.Armor++;
                            else if (item == "Health Potion")
                                player.HealthPotions++;
                            else if (item == "Upgraded Weapon")
                                player.Damage++;
                        }
                        break;
                    case "N":
                        consequence = ("\tYou decided not to purchase anything");
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
