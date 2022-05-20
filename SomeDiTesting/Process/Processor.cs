using SomeDiTesting.Apis;
using SomeDiTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeDiTesting.Process
{
    class Processor
    {
        private readonly IEnumerable<IApi> _apis;
        private readonly WorkItem _item;
        public Processor(IEnumerable<IApi> apis, WorkItem item)
        {
            _apis = apis;
            _item = item;
        }

        public void Process()
        {
            IApi api = _apis.Single(x => x.Id == _item.Api);
            string response = api.GetResponse();

            Console.WriteLine(response);
        }
    }
}
