using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol1ServicesEjer4
{
    class Horse
    {
        static readonly object control = new object();
        private int run;
        private int position;
        public bool winner = false;
        public bool dead = false;

        public Horse(int position)
        {
            this.position = position;
        }

        public void Run(object a)
        {
            lock (control)
            {
                run = run + Convert.ToInt32(a);
                if (run >100)
                {
                    run = 100;
                }
            }

            while (run != 100) 
            {
                lock (control)
                {

                    Console.SetCursorPosition(run, position);
                    Console.Write("@" );
                    Console.SetCursorPosition(run, position);
                    Console.Write(" ");
                    if(run == 100)
                    {
                        Console.SetCursorPosition(run, position);
                        Console.Write("@");
                        winner = true;
                    }
                }
            }

        }

    }
}
