using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDDD.Domain.Interfaces.Repositories //Contracts
{
    //Interface generica/base de repositorio onde faz-se o CRUD padrão
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
