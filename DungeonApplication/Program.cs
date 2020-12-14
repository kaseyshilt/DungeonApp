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
            //This is the program that will control the flow of the overall application. All classes will be created in separate files and referred to in this program to allows us to use instances of the various objects we need (Weapons, Monsters, Combat functionality).

            Console.Title = "DUNGEON OF DOOM";
            Console.WriteLine("Your journey begins...");
            //running total variable that will keep track of the score
            int score = 0;

            //TODO 1. Create a Player - need to learn about custom classes
            //TODO 2. Create a Weapon
            Weapon sword = new Weapon(1, 8, "Long Sword", 10, true);
            Player p1 = new Player("Sir Arthur", 70, 2, 40, 40, Race.Canadian, sword);

            //TODO 3. Create a loop for the room and monster
            bool exit = false;
            do
            {
                //TODO Create the room
                Console.WriteLine(GetRoom());

                //TODO Create the monster
                Rabbit r1 = new Rabbit();
                Rabbit r2 = new Rabbit("White Rabbit", 25, 25, 35, 20, 2, 8, "Thats no ordinary rabbit, look at da bones!", true);
                Dragon d1 = new Dragon();
                Dragon d2 = new Dragon("Mark", 35, 35, 30, 30, 3, 7, "Look ordinary but packs a punch", true);
                Turtle t1 = new Turtle();
                Turtle t2 = new Turtle("Leonardo", 20, 20, 25, 40, 0, 10, "Totally awesome dude!", 20, 17);

                //since all our child classes are type Monster, all can be place in an array of Monster objects. 
                Monster[] monsters = { r1, r2, d1, d2, t1, t2};

                //randomly select a monster from the array
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                //TODO 4. Create a Menu of Options
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
                        

                    //TODO 5. Catch the user choice
                    //ReadKey(true) - keeps the key press from generating its corresponding character on the screen. .Key aligns the information to stored in the same datatype
                    //ReadKey = static & Key is the instance in a way
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    //TODO 6. Clear the Console
                    Console.Clear();

                    //TODO 7. Build out the switch that determines what functionality the user wants
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Player Attacks!");
                            //TODO 8. Handle the Attack Sequence
                            Combat.DoBattle(p1, monster);
                            //TODO 9. Handle if the player wins
                            if (monster.Life <= 0)
                            {
                                //the monster dies - you could put some logi here to have the player get items, get life back, or something similar due to defeating the monster.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou defeated {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!");
                            //TODO 10. Monster gets a free attack
                            Console.WriteLine($"\n{monster.Name} attacks you as you run away!\n");
                            //TODO 11. Exit the inner loop and get a new monster/room
                            Combat.DoAttack(monster, p1);
                            reload = true;//exit the inner loop and get a new room for the monster
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info\n");
                            //TODO 12. Print out the player info
                            Console.WriteLine(p1);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info\n");
                            Console.WriteLine(monster);
                            //TODO 13. Print out the monster info
                            break;
                        case ConsoleKey.X:
                            Console.WriteLine("Nobody likes a quitter! Be gone!");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Thou hast chosen improperly...triest thou again!");
                            break;
                    }
                    #endregion

                    //TODO 14. Check the player's life points before continuing

                } while (!exit && !reload);
                

            } while (!exit);//exit the program

            //Tell the user the game has ended and give them their score
            //Ternary operator
            Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s."));


        }//end Main()

        //TODO 15. Create a method to get a room & plug it in (call to it) where we need to load a new room in the outside do while loop

        private static string GetRoom()
        {
            string[] rooms =
{
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on   you.",
                "You arrive in a room filled with chairs and a ticket stub      machine...DMV",
                "You enter a quiet library... silence... nothing but silence....",
                "As you enter the room, you realize you are standing on a platform          surrounded by     sharks",
                "Oh my.... what is that smell? You appear to be standing in a   compost   pile",
                "You enter a dark room and all you can hear is hair band music      blaring....  This     is going to be bad!",
                "Oh no.... the worst of them all... Oprah's bedroom....",
                "The room looks just like the room you are sitting in right now...  or   does  it?"
                };

            Random rand = new Random();
            //since the max value is exclusive in the next(), we can just call to the rooms.length

            int indexNbr = rand.Next(rooms.Length);
            string room = "***** NEW ROOM *****\n\n" +
                rooms[indexNbr] + "\n\n";

            return room;

        }//end getroom()

    }//end class
}//end namespace
