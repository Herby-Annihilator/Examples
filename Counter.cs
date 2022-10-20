using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class Counter : ICounter
    {
        private int _value;
        public Counter()
        {
            Random random = new Random();
            _value = random.Next();
        }
        public int Value => _value;
    }
}
