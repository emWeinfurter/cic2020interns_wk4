using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ibm.Br.Cic.Internship.Covid.Be.Configuration;
using Ibm.Br.Cic.Internship.Covid.Be.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ibm.Br.Cic.Internship.Covid
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            ConfigureCorsOriginList();
        }

        public IConfiguration Configuration { get; }
        private string[] _origins;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddHttpClient();
            services.AddResponseCaching();
            services.AddTransient<IApify, ApifyService>();
            services.AddSingleton<ILocator, LocatorService>();

            //Task: Inject Covid19ApiService
            //Add Covid19ApiService as Transient
            services.AddTransient<ICovid19Api, Covid19ApiService>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(_origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();
            
            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureCorsOriginList()
        {
            var corsDomains = Configuration.GetSection("CorsOrigin").Get<CorsConfig>().Domains;
            var corsList = new List<string>();
            foreach (var domain in corsDomains)
            {
                corsList.Add($"http://{domain.Trim()}");
                corsList.Add($"https://{domain.Trim()}");
            }
            _origins = corsList.ToArray();
        }
    }
}
