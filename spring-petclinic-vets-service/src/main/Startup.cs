using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Connector.SqlServer.EFCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Steeltoe.Management.Tracing;
using spring_petclinic_vets_api.Data;

namespace spring_petclinic_vets_api
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      Configuration = configuration;
      Environment = env;
    }

    public IWebHostEnvironment Environment { get; }
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services) {
      //DATA CONTEXT
      switch (Environment.EnvironmentName) {
        case ("Development"):
        case ("Docker"):
          services.AddDbContext<VetsContext>(options => options.UseInMemoryDatabase("PetClinic_Vets"));
          break;
        default:
          services.AddDbContext<VetsContext>(options => options.UseSqlServer(Configuration));
          break;
      };

      //REPOSITORIES
      services.AddScoped<Repository.IVets, Repository.Vets>();

      services.AddControllers();

      services.AddDistributedTracing(Configuration, builder => builder.UseZipkinWithTraceOptions(services));

      services.AddSwaggerGen();

      services.AddAuthorization();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, VetsContext dbContext)
    {
      switch (Environment.EnvironmentName) {
        case ("Development"):
        case ("Docker"):
          logger.LogInformation("Running as development environment");
          app.UseDeveloperExceptionPage();

          dbContext.SeedAll();
          break;
        default:
          break;
      };
      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Clinic Vets Service");
      });

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
