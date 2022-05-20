using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeDiTesting.Apis
{
    class SadApi : IApi
    {
        public int Id => 2;
        public string GetResponse()
        {
            return "I'm so sad :(";
        }
    }
}
