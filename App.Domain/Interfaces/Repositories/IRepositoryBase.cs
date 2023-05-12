using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);
        void Save(TEntity obj);
        Task<TEntity> SaveAsync(TEntity obj);
        void Update(TEntity obj);
        void Delete(Guid id);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbContext Context();
        bool SaveOrUpdate(TEntity obj);
    }
}
