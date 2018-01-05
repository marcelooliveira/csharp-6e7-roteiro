using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R12
{
    class CSharp6
    {
        public CSharp6()
        {
            Task.Run(() => DoThings());
        }

        static Task DoThings()
        {
            return Task.FromResult(0);
        }
    }
}
