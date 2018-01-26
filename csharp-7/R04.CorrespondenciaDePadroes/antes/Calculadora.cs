using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace csharp7.R04.antes
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
            calculadora.Somar(new int[] { 4, 5, 6});
            calculadora.Somar(new decimal[] { 4.1m, 5.2m, 6.3m});
            calculadora.Somar(new double[] { 4.1, 5.2, 6.3});
            calculadora.Somar("20");
            calculadora.Somar(new object[] { "20", 100, 150m, 24.0 });
        }
    }

    class Calculadora
    {
        public double Soma { get; private set; } = 0d;

        public void Somar(object parametro)
        {
            Console.WriteLine($"Parâmetro: {parametro}");
            switch (parametro)
            {
                case string str:
                    if (double.TryParse(str, out double val)) Somar(val);
                    break;
                case double valor:
                    Soma += valor;
                    break;
                case decimal valor:
                    Soma += (double)valor;
                    break;
                case int valor:
                    Soma += valor;
                    break;
                case object[] colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                case double[] colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                case decimal[] colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                case int[] colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Valor atual: {Soma}");
            Console.WriteLine();
        }
    }
}
