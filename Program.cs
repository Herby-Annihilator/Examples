using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Formats.Asn1.AsnWriter;

namespace Examples
{
    public class Program
    {
        private static IHost _host;
        private static IHost Hosting => _host ??= CreateHostBuilder().Build();
        private static IServiceProvider _services = Hosting.Services;
        private static IHostBuilder CreateHostBuilder() => Host
            .CreateDefaultBuilder()
            .UseEnvironment("Development")
            .ConfigureServices(ConfigureServices);
        private static void ConfigureServices(HostBuilderContext context,
            IServiceCollection services) => services
            .AddTransient<ICounter, Counter>()
            .AddTransient<CounterService>();

        public static async Task Main(string[] args)
        {
            await Hosting.StartAsync();
            Console.WriteLine("\r\nRequest 1:");
            RequestWithoutScope();
            Console.WriteLine("\r\nRequest 2:");
            SendRequest();
            Console.ReadKey(true);
            await Hosting.StopAsync();
        }

        private static void SendRequest()
        {
            using (var scope = _services.CreateScope())
            {
                ICounter counter = scope.ServiceProvider.GetRequiredService<ICounter>();
                CounterService service = scope.ServiceProvider.GetRequiredService<CounterService>();
                Console.WriteLine($"\tCounter: {counter.Value}; CounterService: {service.UseCounter()}\r\n");
            }
        }

        private static void RequestWithoutScope()
        {
            ICounter counter = _services.GetRequiredService<ICounter>();
            CounterService service = _services.GetRequiredService<CounterService>();
            Console.WriteLine($"\tCounter: {counter.Value}; CounterService: {service.UseCounter()}\r\n");
        }
    }
}