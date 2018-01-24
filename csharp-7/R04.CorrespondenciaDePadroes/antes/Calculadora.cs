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
            var entradas = new Stack<object>();
            entradas.Push(2);
            entradas.Push("+");
            entradas.Push(3);

            var calculadora = new Calculadora();
            foreach (var entrada in entradas)
            {
                calculadora.Digitar(entradas);
            }

            double valor = calculadora.Valor;
            Console.WriteLine(valor);
        }
    }

    internal class Calculadora
    {
        public Calculadora()
        {
        }

        public double Valor { get; internal set; }
        public double Display { get; internal set; }
        public object UltimaEntrada { get; internal set; }

        internal void Digitar(object entrada)
        {
            switch (entrada)
            {
                case int valor:
                    break;
                case "+":
                    break;
                default:
                    break;
            }
        }
    }
}
