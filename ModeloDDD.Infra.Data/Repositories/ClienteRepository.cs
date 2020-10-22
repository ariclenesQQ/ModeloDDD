using ModeloDDD.Domain.Entities;
using ModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDDD.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        
    }
}
