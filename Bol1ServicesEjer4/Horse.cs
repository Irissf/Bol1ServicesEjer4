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
        static Random rand = new Random(); // tiene que ser static para que no sea el mismo número para todos los caballos
        public int position;
        public int sleep;
        public string name;
       

        public Horse(int position, string name)
        {
            this.name = name;
            this.position = position;
        }

        public void Run()
        {
            position = position + rand.Next(1, 11);
            
        }

        public int Sleep()
        {
          return rand.Next(10, 100);
        }

    }
}
