using System;
using System.Reflection;
using Application.AppService.Conta;
using Application.Interface.Conta;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Base;
using Domain.Interfaces.UnitOfWork;
using Domain.Service;
using Domain.Validator.Conta;
using FluentValidation;
using Infra.Persistence;
using Infra.Persistence.Repository;
using Infra.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>();

            services.AddControllers();
            services.AddRouting();

            
            services.AddScoped<IRepository<Conta>, ContaRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IService<Conta>, ContaService>();
            
            services.AddScoped<IContaAppService, ContaAppService>();
            
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddAutoMapper(Assembly.Load("Application"));
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc(
                    "v1", new OpenApiInfo { 
                        Title = "Contas API",
                        Version = "v1",
                        Description = "Teste seletivo Contas BD",
                        Contact = new OpenApiContact
                        {
                            Name = "Breno Felix",
                            Email = "brenodml@live.com",
                            Url = new Uri("https://www.linkedin.com/in/breno-felix-de-souza-49186b131/"),
                        }
                        
                       }
                    
                    );
            });
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddTransient(typeof(IValidator<Conta>), typeof(ContaValidation));
           

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contas API");
                c.RoutePrefix = "";
                c.DocumentTitle = "Contas API";
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }
    }
}