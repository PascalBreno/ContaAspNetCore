using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Base;
using Domain.Service;
using Domain.Service.Base;
using Infra.Persistence.Repository;
using Infra.Persistence.Repository.Base;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class DI
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IService<>), typeof(Service<>));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            
            
            services.AddSingleton(typeof(IContaService), typeof(ContaService));
            services.AddSingleton(typeof(IContaRepository), typeof(ContaRepository));


        }
    }
}