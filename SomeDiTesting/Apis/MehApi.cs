using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeDiTesting.Apis
{
    class MehApi : IApi
    {
        public int Id => 1;
        public string GetResponse()
        {
            return "It's so meh!";
        }
    }
}
