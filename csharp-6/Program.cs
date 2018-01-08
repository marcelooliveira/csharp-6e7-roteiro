using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6e7_roteiro
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menus = new string[] {
                "01.PropriedadesAutomaticasSomenteLeitura",
                "02.InicializadoresDePropriedadeAutomatica",
                "03.MembrosComCorpoDeExpressao",
                "04.UsingStatic",
                "05.OperadoresNullCondicionais",
                "06.InterpolacaoDeCadeiaDeCaracteres",
                "07.FiltrosDeExcecao",
                "08.ExpressoesNameOf",
                "09.AwaitEmBlocosCatchEFinally",
                "10.InicializadoresDeIndice",
                "11.MetodosDeExtensaoParaInicializadoresDeColecao",
                "12.ResolucaoDeSobrecargaAprimorada"
            };

            Console.WriteLine("ÍNDICE DE PROGRAMAS");
            Console.WriteLine("===================");

            foreach (var menu in menus)
            {
                Console.WriteLine(menu);
            }

            Console.WriteLine();
            Console.WriteLine("Escolha um programa:");

            int programa = 0;
            string line;
            do
            {
                line = Console.ReadLine();
                Int32.TryParse(line, out programa);
                switch (programa)
                {
                    case 1:
                        new CSharp6.R01.Programa().Main();
                        break;
                    case 2:
                        new CSharp6.R02.Programa().Main();
                        break;
                    case 3:
                        new CSharp6.R03.Programa().Main();
                        break;
                    case 4:
                        new CSharp6.R04.Programa().Main();
                        break;
                    case 5:
                        new CSharp6.R05.Programa().Main();
                        break;
                    case 6:
                        new CSharp6.R06.Programa().Main();
                        break;
                    case 7:
                        new CSharp6.R07.Programa().Main();
                        break;
                    case 8:
                        new CSharp6.R08.Programa().Main();
                        break;
                    case 9:
                        new CSharp6.R09.Programa().Main();
                        break;
                    case 10:
                        new CSharp6.R10.Programa().Main();
                        break;
                    case 11:
                        new CSharp6.R11.Programa().Main();
                        break;
                    case 12:
                        new CSharp6.R12.Programa().Main();
                        break;         
                    default:
                        break;
                }

            } while (line.Length > 0);
        }
    }
}
