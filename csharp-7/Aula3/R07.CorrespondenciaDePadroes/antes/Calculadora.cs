using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace csharp7.R07.antes
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            Console.WriteLine("Calculadora Para Somar Qualquer Tipo");
            Console.WriteLine("====================================");
            Console.WriteLine();

            var calculadora = new Calculadora();
            calculadora.Somar(2); //int
            calculadora.Somar(3.0m); //decimal
            calculadora.Somar(3.0); //double
            calculadora.Somar(new int[] { 4, 5, 6 });
            calculadora.Somar(new decimal[] { 4.1m, 5.2m, 6.3m });
            calculadora.Somar(new double[] { 4.1, 5.2, 6.3 });
            calculadora.Somar("20");
            calculadora.Somar("R$ 20");
            calculadora.Somar("[20]");
            calculadora.Somar(new object[] { "20", 100, 150m, 24.0, "R$ 12,34" });
        }
    }

    class Calculadora
    {
        private const string NUMERO_ENTRE_COLCHETES = @"\[(\d+)\]";

        public double Soma { get; private set; } = 0d;

        public void Somar(object parametro)
        {
            int valorInt = 0;
            decimal valorDecimal = 0;
            double valorDouble = 0;
            var cultura = System.Globalization.CultureInfo.CurrentCulture;

            if (double.TryParse(parametro.ToString(), NumberStyles.Currency, cultura.NumberFormat, out valorDouble))
            {
                Console.WriteLine($"Total anterior: {Soma}");
                Console.WriteLine($"Somando: {valorDouble}");
                Soma += valorDouble;
                Console.WriteLine($"Total atual: {Soma}");
                Console.WriteLine();
                return;
            }

            if (parametro is string)
            {
                var str = parametro as string;
                if (Regex.Match(str, NUMERO_ENTRE_COLCHETES).Success)
                {
                    Somar(Regex.Match(str, NUMERO_ENTRE_COLCHETES).Groups[1].Value);
                    return;
                }
            }

            if (int.TryParse(parametro.ToString(), out valorInt))
            {
                Somar(valorInt);
                return;
            }

            if (decimal.TryParse(parametro.ToString(), out valorDecimal))
            {
                Somar(valorDecimal);
                return;
            }

            var colecao = parametro as IEnumerable<object>;
            if (colecao != null)
            {
                foreach (var item in colecao)
                {
                    Somar(item);
                }
                return;
            }

            var colecaoInt = parametro as IEnumerable<int>;
            if (colecaoInt != null)
            {
                foreach (var item in colecaoInt)
                {
                    Somar(item);
                }
                return;
            }

            var colecaoDecimal = parametro as IEnumerable<decimal>;
            if (colecaoDecimal != null)
            {
                foreach (var item in colecaoDecimal)
                {
                    Somar(item);
                }
                return;
            }

            var colecaoDouble = parametro as IEnumerable<double>;
            if (colecaoDouble != null)
            {
                foreach (var item in colecaoDouble)
                {
                    Somar(item);
                }
                return;
            }
        }
    }
}
