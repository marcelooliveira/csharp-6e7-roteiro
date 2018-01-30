using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp7.R09.antes
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            var data = GetValor();

            Console.WriteLine(data.Count());
            Console.WriteLine("complete");
            Console.ReadLine();
        }

        static IEnumerable<int> GetValor()
        {
            Console.WriteLine("Data From Task");
            for (int i = 0; i < 1000000; i++)
            {
                yield return Task.FromResult(i * 10).Result;
            }
        }
    }
}
