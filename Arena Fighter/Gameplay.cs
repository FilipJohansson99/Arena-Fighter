using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    public class Gameplay
    {
        public bool Morning(int day, Character player, StringBuilder combatLog)
        {
            var validSelection = true;
            var retired = false;
            Console.WriteLine("0 - Retire\n1 - Go Adventuring");
            if (player.SkillPoints > 0)
            {
                Console.WriteLine("2 - Level Up");
            }
            if (player.HealthPotions > 0)
            {
                Console.WriteLine("3 - Consume Health Potion");
            }
            Console.WriteLine("");
            Console.WriteLine($"Day: {day}");
            do
            {
                validSelection = true;

                var op = Console.ReadLine();
                switch (op)
                {
                    case "0":
                        retired = true;
                        break;
                    case "1":
                        Events(player, combatLog, day);
                        break;
                    case "2":
                        if (player.SkillPoints > 0)
                        {

                        }
                        else
                            validSelection = false;
                        break;
                    case "3":
                        if (player.HealthPotions > 0)
                        {
                            player.HealthPotions -= 1;
                            player.Health = 10;
                        }
                        else
                            validSelection = false;
                        break;
                    default:
                        validSelection = false;
                        Console.WriteLine("Invalid Selection.");
                        break;
                }
            } while (!validSelection);
            return retired;
        }
        public int Randomizer(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void Events(Character player, StringBuilder combatLog, int day)
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
                            Character.DrawStats(player);
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
