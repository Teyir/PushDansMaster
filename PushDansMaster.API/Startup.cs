using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace PushDansMaster.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PushDansMaster.API", Version = "v1" });
            });

            services.AddSingleton(typeof(IFournisseurService), new FournisseurService());
            services.AddSingleton(typeof(IAdherentService), new AdherentService());
            services.AddSingleton(typeof(IPanierAdherentService), new PanierAdherentService());
            services.AddSingleton(typeof(IPanierGlobalService), new PanierGlobalService());
            services.AddSingleton(typeof(IReferenceService), new ReferenceService());
            services.AddSingleton(typeof(ILigneAdherentService), new LigneAdherentService());
            services.AddSingleton(typeof(ILigneGlobalService), new LigneGlobalService());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PushDansMaster.API v1"));
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
