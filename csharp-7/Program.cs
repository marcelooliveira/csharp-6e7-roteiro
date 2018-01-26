using csharp7;
using System;
using static System.Console;

namespace CSharp7
{
    class Program
    {
        static string[] menus = new string[] {
            "1. Variáveis out",
            "2. Tuplas",
            "3. Descartes",
            "4. Correspondência de Padrões",
            "5. Locais e retornos de Ref",
            "6. Funções Locais",
            "7. Mais Membros com Corpo de Expressão"
        };

        static void Main(string[] args)
        {

            WriteLine("ÍNDICE DE PROGRAMAS");
            WriteLine("===================");


            string line;
            do
            {
                foreach (var menu in menus)
                {
                    WriteLine(menu);
                }

                WriteLine();
                WriteLine("Escolha um programa:");

                line = ReadLine();

                Int32.TryParse(line, out int programa);

                Executar(programa);

                WriteLine();
                WriteLine("PRESSIONE UMA TECLA PARA CONTINUAR...");
                ReadKey();
                Clear();
            } while (line.Length > 0);
        }

        private static void Executar(int programa)
        {
            if (programa > 0)
            {
                ImprimirTitulo(programa);
                ForegroundColor = ConsoleColor.Yellow;
                ExecutarPasso(programa, "antes");
                ForegroundColor = ConsoleColor.Green;
                ExecutarPasso(programa, "depois");
                ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ImprimirTitulo(int programa)
        {
            WriteLine();
            WriteLine(menus[programa - 1]);
            WriteLine();
        }

        private static void ExecutarPasso(int programa, string step)
        {
            WriteLine(step.ToUpper());
            WriteLine(new string('=', 100));
            var type = Type.GetType($"csharp7.R{programa:00}.{step}.MenuItem");
            ((MenuItem)Activator.CreateInstance(type)).Main();
            WriteLine();
        }
    }
}
