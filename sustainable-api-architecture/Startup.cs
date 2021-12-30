using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sustainable_api_architecture.Infrastructure;
using sustainable_api_architecture.Repositories;
using sustainable_api_architecture.Services;

namespace sustainable_api_architecture
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Here we are defining what dependencies to inject based on the interfaces
            // needed by each class.

            // The file reader injected into the repository, so that the repo itself
            // doesn't know anything about the underlying data source. In a real-world
            // application with DB etc. you can either directly use the ORM if one is
            // provided, or inject an adapter as I've done here
            services.AddScoped<Repositories.IDataReader, ForecastFileReader>();

            // The services that need the repo are injected here, so that the services
            // don't know anything about how it's getting its data
            services.AddScoped<IAllForecasts, ForecastRepository>();

            // Finally, we inject the controller with the service. As we're in the API layer
            // and the service is in the Application layer, we could reference the class directly.
            // However, it's best to use dependency injection as the framework will inject all the
            // dependencies for us (in our case, inject the service with a repo, and inject the repo with a file reader).
            // Furthermore, if we wanted to test the controller in isolation, we could do so by injecting a stub of the repo
            // instead of the real implementation
            services.AddScoped<IRetrieveForecast, RetrieveForecast>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

