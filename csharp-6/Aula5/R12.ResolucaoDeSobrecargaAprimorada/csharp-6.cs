using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R12
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("12. Resolução De Sobrecarga Aprimorada");
        }

        public Programa()
        {
            Task.Run(() => FazerAlgo());

            //Com a Sobrecarga Aprimorada, agora também é permitida a sintaxe abaixo:

            Task.Run(FazerAlgo);
        }

        static Task FazerAlgo()
        {
            return Task.FromResult(0);
        }
    }
}
