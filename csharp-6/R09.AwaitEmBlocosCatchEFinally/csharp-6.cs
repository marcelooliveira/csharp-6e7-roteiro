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
        public void Main()
        {
            Console.WriteLine("Programa 9");
        }
    }

    class CSharp6
    {
        public static async Task<string> FazerRequisicaoELogarFalhas()
        {
            await logarEntradaNoMetodo();
            var cliente = new System.Net.Http.HttpClient();
            var streamTask = cliente.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                await logarErro("Recuperado da redireção", e);
                return "Site Mudou de Endereço";
            }
            finally
            {
                await logarSaidaDoMetodo();
                cliente.Dispose();
            }
        }

        private static Task logarSaidaDoMetodo()
        {
            throw new NotImplementedException();
        }

        private static Task logarErro(string v, HttpRequestException e)
        {
            throw new NotImplementedException();
        }

        private static Task logarEntradaNoMetodo()
        {
            throw new NotImplementedException();
        }
    }
}
