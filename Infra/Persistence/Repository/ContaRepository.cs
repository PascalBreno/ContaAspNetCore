using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Persistence.Repository.Base;

namespace Infra.Persistence.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(Context context) : base(context)
        {
        }
    }
}