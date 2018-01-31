using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp7.R06.antes
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            var caracteres = Alfabeto.SubconjuntoDoAlfabeto('c', 'o');

            foreach (var caracter in caracteres)
            {
                Console.WriteLine(caracter);
            }
        }
    }

    class Alfabeto
    {
        public static IEnumerable<char> SubconjuntoDoAlfabeto(char inicio, char fim)
        {
            if (inicio < 'a' || inicio > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(inicio), message: "início deve ser uma letra");
            if (fim < 'a' || fim > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(fim), message: "final deve ser uma letra");

            if (fim <= inicio)
                throw new ArgumentException($"{nameof(fim)} deve ser maior que {nameof(inicio)}");

            return implementacaoSubconjuntoDoAlfabeto(inicio, fim);
        }

        private static IEnumerable<char> implementacaoSubconjuntoDoAlfabeto(char inicio, char fim)
        {
            for (var c = inicio; c < fim; c++)
                yield return c;
        }
    }
}
