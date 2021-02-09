using System;
using System.Reflection;
using System.IO;
using Application.AppService.Conta;
using Application.AppService.UnitOfWork;
using Application.Interface.Conta;
using Application.Interface.UnitOfWork;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Base;
using Domain.Interfaces.UnitOfWork;
using Domain.Service;
using Domain.Service.Base;
using Domain.Validator.Conta;
using FluentValidation;
using Imea.Application.Mapper;
using Infra.Persistence;
using Infra.Persistence.Repository;
using Infra.Persistence.Repository.Base;
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

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IUnitOfWorkService), typeof(UnitOfWorkService));
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
            services.AddTransient(typeof(IContaRepository), typeof(ContaRepository));
            services.AddTransient(typeof(IContaService), typeof(ContaService));
            services.AddTransient(typeof(IContaAppService), typeof(ContaAppService));
           

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
            AutoMapperConfig.RegisterMapping();

        }
    }
}