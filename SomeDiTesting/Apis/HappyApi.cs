using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeDiTesting.Apis
{
    class HappyApi : IApi
    {
        public int Id => 0;

        public string GetResponse()
        {
            return "I'm so happy! :)";
        }
    }
}
