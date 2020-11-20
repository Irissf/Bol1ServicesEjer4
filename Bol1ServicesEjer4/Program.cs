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
            Console.WriteLine("ganó");
            Console.ReadLine();
        }    

    }
}
