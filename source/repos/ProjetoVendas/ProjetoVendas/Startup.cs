using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjetoVendas.Context;
using ProjetoVendas.Mapper;
using ProjetoVendas.Model;
using ProjetoVendas.Repositories;
using ProjetoVendas.Repositories.Interface;
using ProjetoVendas.Services;
using ProjetoVendas.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas
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
            services.AddHttpClient("cep");
            services.AddTransient<IServicePessoa, ServicePessoa>();
            services.AddTransient<IRepositoryEndereco, RepositoryEndereco>();
            services.AddTransient<IRepositoryPessoa, RepositoryPessoa>();
            
            var mapConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperDtoEntity()));
            services.AddSingleton(mapConfig.CreateMapper());
            services.AddSwaggerGen();
            services.AddDbContext<ContextDB>((options) => options.UseNpgsql(Configuration.GetConnectionString("StringBase")));
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
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
