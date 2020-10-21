using MartinCostello.Logging.XUnit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using spring_petclinic_vets_api;

namespace spring_petclinic_vets_integration_test
{
  public class CustomersAppFactory<TStartup> : WebApplicationFactory<TStartup>, ITestOutputHelperAccessor where TStartup : class
  {
    public ITestOutputHelper OutputHelper { get; set; }

    public CustomersAppFactory() : base() { }

    protected override IHostBuilder CreateHostBuilder()
    {
      var builder = Program.CreateHostBuilder(new string[] { });

      builder.ConfigureLogging(logging => {
        logging.ClearProviders(); // Remove other loggers
        logging.AddXUnit(OutputHelper); // Use the ITestOutputHelper instance
      });

      builder.UseEnvironment("Development");

      return builder;
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      builder.ConfigureServices(services => {

      });
    }
  }
}
