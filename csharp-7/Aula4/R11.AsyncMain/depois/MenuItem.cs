using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace csharp7.R11.depois
{
    class MenuItem : csharp7.MenuItem
    {
        public async override void Main()
        {
            //obs: O método acima seria o Main do programa: static void Main(string[] args)
            var html = await GetDotNetCountAsync();
            WriteLine(html);
        }

        public async Task<string> GetDotNetCountAsync()
        {
            return await new HttpClient().GetStringAsync("http://www.google.com");
        }
    }
}
