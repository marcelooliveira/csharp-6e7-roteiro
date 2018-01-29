using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp7.R08.antes
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            IFormatador formatadorCNPJ = new FormatadorCNPJ();
            string codigoCNPJ = "12345678000099";
            string codigoCNPJ2 = "12.345.678/0000-99";
            string codigoCNPJ3 = null;

            ImprimirEstaFormatado(formatadorCNPJ, codigoCNPJ);
            ImprimirEstaFormatado(formatadorCNPJ, codigoCNPJ2);

            ImprimirCodigoFormatado(formatadorCNPJ, codigoCNPJ);
            ImprimirCodigoDesformatado(formatadorCNPJ, codigoCNPJ2);
            ImprimirCodigoDesformatado(formatadorCNPJ, codigoCNPJ3);

            IFormatador formatadorCPF = new FormatadorCPF();
            string codigoCPF = "12345678001";
            string codigoCPF2 = "123.456.780-01";
            string codigoCPF3 = null;

            ImprimirEstaFormatado(formatadorCNPJ, codigoCPF);
            ImprimirEstaFormatado(formatadorCNPJ, codigoCPF2);

            ImprimirCodigoFormatado(formatadorCPF, codigoCPF);
            ImprimirCodigoDesformatado(formatadorCPF, codigoCPF2);
            ImprimirCodigoDesformatado(formatadorCPF, codigoCPF3);
        }

        private static void ImprimirEstaFormatado(IFormatador formatador, string codigo)
        {
            try
            {
                if (formatador.EstaFormatado(codigo))
                {
                    Console.WriteLine($"Código {codigo} ESTÁ formatado");
                    return;
                }
                Console.WriteLine($"Código {codigo} NÃO ESTÁ formatado");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static void ImprimirCodigoFormatado(IFormatador formatador, string codigo)
        {
            try
            {
                Console.WriteLine($"Código formatado: {formatador.Formatar(codigo)}");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static void ImprimirCodigoDesformatado(IFormatador formatador, string codigo)
        {
            try
            {
                Console.WriteLine($"Código desformatado: {formatador.Desformatar(codigo)}");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
