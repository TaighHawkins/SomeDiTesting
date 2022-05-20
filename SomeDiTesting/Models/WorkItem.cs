using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeDiTesting.Models
{
    class WorkItem
    {
        public Guid Id { get; internal set; }
        public int Api { get; internal set; }
    }
}
