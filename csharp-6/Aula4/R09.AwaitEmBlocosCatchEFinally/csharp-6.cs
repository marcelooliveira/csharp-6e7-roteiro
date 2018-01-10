using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R09
{
    class Programa
    {
        public async void Main()
        {
            Console.WriteLine("9. Await Em Blocos Catch E Finally");

            await FazerRequisicaoELogarFalhas(); 
        }

        public async Task<string> FazerRequisicaoELogarFalhas()
        {
            await LogarEntradaNoMetodo();
            var cliente = new System.Net.Http.HttpClient();
            var streamTask = cliente.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                await LogarErro("Recuperado da redireção", e);
                return "Site Mudou de Endereço";
            }
            finally
            {
                await LogarSaidaDoMetodo();
                cliente.Dispose();
            }
        }

        private static Task LogarSaidaDoMetodo()
        {
            return new Task(() =>
            {
                Console.WriteLine("LogarSaidaDoMetodo");
            });
        }

        private static Task LogarErro(string v, HttpRequestException e)
        {
            return new Task(() =>
            {
                Console.WriteLine("LogarErro");
            });
        }

        private static Task LogarEntradaNoMetodo()
        {
            return new Task(() =>
            {
                Console.WriteLine("LogarEntradaNoMetodo");
            });
        }
    }
}
