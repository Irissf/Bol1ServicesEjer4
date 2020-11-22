using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bol1ServicesEjer4
{
    class Program
    {
        static readonly object key = new object();
        static bool finish = false;
        static string winner = "";
        static void Main(string[] args)
        {
            string option = "";
            string horseFav = "";
            do
            {
                Console.Clear();
                Console.WriteLine("select your favorite horse by its number");
                Console.WriteLine("1->horse1, 2->horse2, 3->horse3, 4->horse4, 5->horse5");
                horseFav = Console.ReadLine();
                Console.Clear();
                finish = false;

                List<Horse> horses = new List<Horse>();
                horses.Add(new Horse(0, 1, "horse 1"));
                horses.Add(new Horse(0, 2, "horse 2"));
                horses.Add(new Horse(0, 3, "horse 3"));
                horses.Add(new Horse(0, 4, "horse 4"));
                horses.Add(new Horse(0, 5, "horse 5"));

                Console.WriteLine("Your horse is" + horseFav);
                Console.SetCursorPosition(100, 1);
                Console.WriteLine("|");
                Console.SetCursorPosition(100, 2);
                Console.WriteLine("|");
                Console.SetCursorPosition(100, 3);
                Console.WriteLine("|");
                Console.SetCursorPosition(100, 4);
                Console.WriteLine("|");
                Console.SetCursorPosition(100, 5);
                Console.WriteLine("|");

                Thread[] threads = new Thread[5];
                for (int i = 0; i < horses.Count; i++)
                {
                    threads[i] = new Thread(RunHorse);
                    threads[i].Start(horses[i]);
                }
                    threads[0].Join();

                Console.SetCursorPosition(0, 6);
                if (winner == horseFav)
                {
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Congratulations");
                }
                else
                {
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("The winner is the horse number: "+winner);
                }
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Press 1 to play again, any key to exit");
                Console.SetCursorPosition(0, 8);

                option = Console.ReadLine();

            } while (option == "1");

        }

        public static void RunHorse(object a)
        {
            Horse horse = (Horse)a;
            while (!finish)
            {
                lock (key)
                {
                    if (!finish)
                    {
                        horse.Run();
                        if (horse.position >= 100) //meta
                        {
                            horse.position = 100;
                            Console.SetCursorPosition(horse.position, horse.line);
                            Console.WriteLine(horse.line);
                            winner = Convert.ToString( horse.line);
                            finish = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(horse.position, horse.line);
                            Console.WriteLine(horse.line);
                            Console.SetCursorPosition(horse.position, horse.line);
                            Console.WriteLine("-"); //para ver por donde pasas
                        }
                    }
                    
                } //fin lock
                Thread.Sleep(horse.Sleep());
            }//fin while
            if (finish)
            {
                lock (key)
                {
                    {
                        Console.SetCursorPosition(horse.position, horse.line);
                        Console.WriteLine(horse.line);
                    }
                }
            }
                
        }
    }
}



//========================================UNOS SOLO=========================================================================
/*class Program
    {
        static readonly object key = new object();
        static bool finish = false;
        static void Main(string[] args)
        {
            Horse horse = new Horse(0,0,"horse 1");
            Thread horse1 = new Thread(RunHorse);
            horse1.Start(horse);
            horse1.Join();
            Console.ReadLine();
        }

        public static void RunHorse(object a)
        {
            Horse horse = (Horse)a;
            while (!finish)
            {
                lock (key)
                {
                    if (!finish)
                    {
                        horse.Run();
                        if (horse.position >= 100)
                        {
                            horse.position = 100;
                            finish = true;
                        }
                        Console.SetCursorPosition(horse.position, horse.line);
                        Console.WriteLine(horse.line);
                    }
                    
                }
                Thread.Sleep(horse.Sleep());
            }
        }
    }*/
