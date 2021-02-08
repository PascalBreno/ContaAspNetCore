using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(Context context) : base(context)
        {
        }
    }
}