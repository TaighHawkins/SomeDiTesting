using Microsoft.Extensions.DependencyInjection;
using SomeDiTesting.Models;
using SomeDiTesting.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeDiTesting.PretendWorker
{
    public class Worker
    {
        private readonly IServiceProvider _services;

        public Worker(IServiceProvider services)
        {
            _services = services;
        }

        internal async Task WorkerLoop()
        {
            try
            {
                int count = 0;
                var randomGenerator = new Random((int)DateTimeOffset.UtcNow.Ticks);
                while (count++ < 100)
                {
                    WorkItem item = new()
                    {
                        Id = Guid.NewGuid(),
                        Api = randomGenerator.Next(3)
                    };
                    using var scope = _services.CreateScope();

                    Processor processor = ActivatorUtilities.CreateInstance<Processor>(scope.ServiceProvider, item);
                    processor.Process();
                }


                count = 0;
                while (count++ < 100)
                {
                    WorkItem item = new()
                    {
                        Id = Guid.NewGuid(),
                        Api = randomGenerator.Next(3)
                    };
                    using var scope = _services.CreateScope();

                    Processor processor = ActivatorUtilities.CreateInstance<Processor>(scope.ServiceProvider, item);

                    // This works - best when you need a very, very specific constructor
                    //var factory = ActivatorUtilities.CreateFactory(typeof(Supervisor), new Type[] { typeof(Processor) });
                    //Supervisor supervisor = factory.Invoke(scope.ServiceProvider, new object[] { processor }) as Supervisor;

                    // This can be used with previously created instances and still leverages DI for the rest
                    Supervisor supervisor = ActivatorUtilities.CreateInstance<Supervisor>(scope.ServiceProvider, processor);
                    supervisor.Supervise();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
