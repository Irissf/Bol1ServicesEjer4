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
        static readonly object a = new object();
        static Random random = new Random();

        static void Main(string[] args)
        {
            List<Horse> horses = new List<Horse>();
            Thread[] threads = new Thread[5];
            int numRun = 0;
            int winner = 0;
            bool win = false;

            horses.Add(new Horse(1));//5 caballos, cada uno en una posición
            horses.Add(new Horse(2));
            horses.Add(new Horse(3));
            horses.Add(new Horse(4));
            horses.Add(new Horse(5));
            while (!win)
            {
                for (int i = 0; i < horses.Count; i++)
                {
                    if (!win)
                    {
                        
                            numRun = RunHorses();

                            threads[i] = new Thread(horses[i].Run); //¿no puede tener parámetros a la que llamas?
                            threads[i].Start(numRun);
                            

                            numRun = RunHorses();
                            Thread.Sleep(numRun); // al acabar dormirá
                        
                    }
                    else
                    {
                        
                            Console.WriteLine("mato");
                    }
                    if (horses[i].winner)
                    {
                        Console.WriteLine("entro aqui");
                        win = true;
                        winner = i;
                        threads[i].Join();
                    }
                }
            
                //PONER UNA VARIABLE EN CABALLO para saber cuando termina, y en el while este cambiar a si esa variable esta a true para continuar

            }
            

            Console.WriteLine("gana");

            Console.ReadLine();
        }
        public static int RunHorses()
        {
            int num = random.Next(1,11);
            return num;
        }



    }
}
