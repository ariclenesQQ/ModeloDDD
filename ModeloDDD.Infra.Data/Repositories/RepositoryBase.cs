using ModeloDDD.Domain.Interfaces.Repositories;
using ModeloDDD.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDDD.Infra.Data.Repositories
{
    //Repositório generico que Recebe a Interface/Contracto
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ModeloDDDContextEF Db = new ModeloDDDContextEF();
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges(); 
        }

        //Podes usar Db.Set<TEntity>().AsNoTracking.ToList() para economizar recursos
        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
