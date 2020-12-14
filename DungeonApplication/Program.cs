using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dungeonlibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "DUNGEON OF DOOM";
            Console.WriteLine("Your journey begins...");
            int score = 0;

            //TODO 2. Create a Weapon
            Weapon blade = new Weapon(2, 10, "Demonic Blade", 20, true);
            Player p1 = new Player("Elon Musk", 60, 8, 40, 50, Race.HumanBorn, blade);

            //TODO 3. Create a loop for the room and monster
            bool exit = false;
            do
            {
                //TODO Create the room
                Console.WriteLine(GetRoom());

                //TODO Create the monster
                Blob b1 = new Blob();
                Blob b2 = new Blob("Big Beefy", 50, 25, 35, 20, 10, 10, "Oh jeez, here comes the scariest blob of them all!", true);
                GodZilla g1 = new GodZilla();
                GodZilla g2 = new GodZilla("GodZilla", 100, 60, 50, 50, 30, 40, "EVERYBODY RUN!!!!!!", true);
                Rammus r1 = new Rammus();
                Rammus r2 = new Rammus("Rammus", 80, 30, 35, 45, 20, 30, "The tankiest of the Dungeon Born!", 20, 17);

                Monster[] monsters = { b1, b2, g1, g2, r1, r2};

                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                // menu
                bool reload = false;
                do
                {
                    #region Menu Loop

                    Console.WriteLine("\n\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                        
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Player Attacks!");
              
                            Combat.DoBattle(p1, monster);
                            
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou defeated {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!");
                            Console.WriteLine($"\n{monster.Name} attacks you as you run away!\n");
                            Combat.DoAttack(monster, p1);
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info\n");
                            Console.WriteLine(p1);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info\n");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                            Console.WriteLine("See you later scaredy cat!");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Please select a valid option.");
                            break;
                    }
                    #endregion

                } while (!exit && !reload);
                

            } while (!exit);

            Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s."));


        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
{
                "Please tell me I am not smelling GodZilla...",
                "Well this is not where I thought I would be when I woke up today.",
                "Hello... Anyone here?"    
                };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);
            string room = "***** NEW ROOM *****\n\n" +
                rooms[indexNbr] + "\n\n";

            return room;

        }//end getroom()

    }//end class
}//end namespace
