using SomeDiTesting.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeDiTesting.Process
{
    class Supervisor
    {
        private readonly Processor _processor;
        private readonly LessThanEffectiveHelper _helper;

        public Supervisor(Processor processor, LessThanEffectiveHelper helper)
        {
            _processor = processor;
            _helper = helper;
        }

        public void Supervise()
        {
            _helper.Help();
            Console.WriteLine("Process beginning...");
            _processor.Process();
            Console.WriteLine("Process ended...");
        }
    }
}
