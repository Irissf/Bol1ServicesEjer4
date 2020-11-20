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
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];
            List<Horse> horses = new List<Horse>();
            string winner = "";

            //=======================================================================
            int x = 0;
            bool finish = false;
            //=======================================================================

            horses.Add(new Horse(x, "caballo1"));
            horses.Add(new Horse(x, "caballo2"));
            horses.Add(new Horse(x, "caballo3"));
            horses.Add(new Horse(x, "caballo4"));
            horses.Add(new Horse(x, "caballo5"));

            Console.SetCursorPosition(100, 0);
            Console.WriteLine("|");
            Console.SetCursorPosition(100, 1);
            Console.WriteLine("|");
            Console.SetCursorPosition(100, 2);
            Console.WriteLine("|");
            Console.SetCursorPosition(100, 3);
            Console.WriteLine("|");
            Console.SetCursorPosition(100, 4);
            Console.WriteLine("|");



            while (!finish) //si lo ponemos dentro del for, solo se hace el caballo 1
            {
                for (int i = 0; i < horses.Count; i++)
                {
                    threads[i] = new Thread(horses[i].Run);
                    threads[i].Start();
                    threads[i].Join();
                    lock (key) //el caballo se lleva la llave y no la devuelve hasta que completa su interior
                    {
                        if (!finish)
                        {
                            if (horses[i].position >= 100)
                            {
                                if (horses[i].position > 100)
                                {
                                    Console.SetCursorPosition(100, i);
                                    Console.Write(i);
                                } //hacer un for que recorrar los caballos, compare el nombre, si es el ganador pone asterisco en 100, el resto en su posicion
                                winner = horses[i].name;
                                finish = true;
                            }
                            else
                            {
                                Console.SetCursorPosition(horses[i].position, i);
                                Console.Write(i);
                                Thread.Sleep(horses[i].Sleep());
                                Console.SetCursorPosition(horses[i].position, i);
                                Console.Write("-"); //para ver el rastro de la carrera o se ve feo
                            }

                        }

                    }
                }
            }

            Console.SetCursorPosition(0, 6);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ganó el " + winner);


            Console.ReadLine();

        }
    }




    /*UN CABALLO SOLO
     * 
     * static readonly object a = new object();

        static void Main(string[] args)
        {
            int end = 0;
            Horse horse = new Horse(0);
            int x=0;
            while (x < 100)
            {
                x = x + horse.Run();
                Console.SetCursorPosition(x, 0);
                Console.Write("*");
            }
            Console.WriteLine("\nganó");
            Console.ReadLine();
        }  */
}
