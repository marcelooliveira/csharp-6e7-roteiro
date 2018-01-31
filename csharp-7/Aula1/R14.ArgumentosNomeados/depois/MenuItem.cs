using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace csharp7.R14.depois
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            //O método pode ser chamado do jeito normal, usando argumentos posicionais.
            ImprimirDetalhesDoPedido("Maria de Fátima", 31, "Caneca Vermelha");

            //Argumentos nomeados podem ser fornecidos para os parâmetros em qualquer ordem.
            ImprimirDetalhesDoPedido(numeroPedido: 31, nomeProduto: "Caneca Vermelha", vendedor: "Maria de Fátima");
            ImprimirDetalhesDoPedido(nomeProduto: "Caneca Vermelha", vendedor: "Maria de Fátima", numeroPedido: 31);

            //Argumentos nomeados misturados com argumentos posicionais são válidos
            //desde que sejam usados em sua posição correta.
            ImprimirDetalhesDoPedido("Maria de Fátima", 31, nomeProduto: "Caneca Vermelha");
            ImprimirDetalhesDoPedido(vendedor: "Maria de Fátima", 31, nomeProduto: "Caneca Vermelha"); // somente a partir do C# 7.2
            ImprimirDetalhesDoPedido("Maria de Fátima", numeroPedido: 31, "Caneca Vermelha"); // somente a partir do C# 7.2

            //Porém, argumentos nomeados misturados com argumentos posicionais são INVÁLIDOS
            //se estiverem fora da ordem.
            // As 3 linhas abaixo geram erro de compilação:

            ////Error CS8323  Named argument 'nomeProduto' is used out-of - position but is followed by an unnamed argument
            //ImprimirDetalhesDoPedido(nomeProduto: "Caneca Vermelha", 31, "Maria de Fátima");
            ////Error   CS8323 Named argument 'vendedor' is used out-of - position but is followed by an unnamed argument
            //ImprimirDetalhesDoPedido(31, vendedor: "Maria de Fátima", "Caneca Vermelha");
            ////Error   CS1744 Named argument 'vendedor' specifies a parameter for which a positional argument has already been given
            //ImprimirDetalhesDoPedido(31, "Caneca Vermelha", vendedor: "Maria de Fátima");
        }

        void ImprimirDetalhesDoPedido(string vendedor, int numeroPedido, string nomeProduto)
        {
            if (string.IsNullOrWhiteSpace(vendedor))
            {
                throw new ArgumentException(message: "Nome de vendedor não pode ser nulo ou vazio.", paramName: nameof(vendedor));
            }

            Console.WriteLine($"Vendedor: {vendedor}, Pedido #: {numeroPedido}, Produto: {nomeProduto}");
        }
    }
}
