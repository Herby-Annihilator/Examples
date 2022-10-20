using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public interface IService
    {
        void DoSomething();
    }

    public class ServiceA : IService
    {
        public void DoSomething() => Console.WriteLine(nameof(ServiceA));
    }

    public class ServiceB : IService
    {
        public void DoSomething() => Console.WriteLine(nameof(ServiceB));
    }
}
