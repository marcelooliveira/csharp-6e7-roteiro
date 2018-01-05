using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R09
{
    class CSharp6
    {
        public static async Task<string> MakeRequestAndLogFailures()
        {
            await logMethodEntrance();
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                await logError("Recovered from redirect", e);
                return "Site Moved";
            }
            finally
            {
                await logMethodExit();
                client.Dispose();
            }
        }

        private static Task logMethodExit()
        {
            throw new NotImplementedException();
        }

        private static Task logError(string v, HttpRequestException e)
        {
            throw new NotImplementedException();
        }

        private static Task logMethodEntrance()
        {
            throw new NotImplementedException();
        }
    }
}
