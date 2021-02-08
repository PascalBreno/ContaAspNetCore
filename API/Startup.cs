using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Base;
using Domain.Service;
using Domain.Service.Base;
using Domain.Validator.Conta;
using FluentValidation;
using Infra.Persistence;
using Infra.Persistence.Repository;
using Infra.Persistence.Repository.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options=>options.UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=ContasBD; Integrated Security=True"));

            services.AddControllers();
            services.AddRouting();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            
            services.AddTransient(typeof(IValidator<Conta>), typeof(ContaValidation));
            services.AddTransient(typeof(IContaRepository), typeof(ContaRepository));
            services.AddTransient(typeof(IContaService), typeof(ContaService));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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