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
        private Random rand = new Random();
        private int position;
       

        public Horse(int position)
        {
            this.position = position;
        }

        public int Run()
        {
            int num = rand.Next(1, 11);
            return num;
        }

    }
}
