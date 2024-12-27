using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kuaforsln.Repository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
        IQueryable<T> Get();
        IQueryable<T> GetAll();
        T Get(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        void Ekle(T entity);
        void Sil(T entity);
        void Guncelle(T entity);
        bool Save();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector, bool azalan = false);
    }
}