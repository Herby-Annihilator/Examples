using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class CounterService
    {
        private ICounter _counter;

        public CounterService(ICounter counter)
        {
            _counter = counter;
        }

        public int UseCounter() => _counter.Value;
    }
}
