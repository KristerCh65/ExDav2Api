using ExDav2Api.Data;
using ExDav2Api.Repositorios.Interface;
using ExDav2Api.Repositorios.Repositorio;
using ExDav2Api.Servicios.Interface;
using ExDav2Api.Servicios.Servicio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api
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
            services.AddDbContext<CoviContext>();

            services.AddControllers();

            services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
            services.AddScoped<IPuestoVacunacionRepositorio, PuestoVacunacionRepositorio>();
            services.AddScoped<ICitaVacunacionRepositorio, CitaVacunacionRepositorio>();

            services.AddScoped<IPersonaAppService, PersonaAppService>();
            services.AddScoped<IPuestoVacunacionAppService, PuestoVacunacionAppService>();
            services.AddScoped<ICitaVacunacionAppService, CitasVacunacionAppService>();

            services.AddMvc().AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(caption => caption.AddPolicy("AllowWebApp", 
                builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExDav2Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExDav2Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowWebApp");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
