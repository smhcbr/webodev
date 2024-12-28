using System;
using System.Linq;
using System.Linq.Expressions;
using kuaforsln.Models;
using Microsoft.EntityFrameworkCore;

namespace kuaforsln.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> Table { get; set; }
        private readonly BerberWebContext _context;
        private readonly DbSet<T> _table;

        public Repository(BerberWebContext context) 
        {
            _context = context;
            _table = context.Set<T>();
        }
        
        public IQueryable<T> Get() => _table;
        public IQueryable<T> GetAll() => _table;

        public T Get(Expression<Func<T, bool>> predicate) => _table.FirstOrDefault(predicate);

        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) 
            => includes.Aggregate(_table.Where(predicate), (current, include) => current.Include(include)).FirstOrDefault();

        public void Ekle(T entity) => _table.Add(entity);

        public void Sil(T entity) => _table.Remove(entity);

        public void Guncelle(T entity) => _table.Update(entity);

        public bool Save() => _context.SaveChanges() > 0; 

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _table.Where(predicate);

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector, bool azalan = false) 
            => azalan ? _table.OrderByDescending(keySelector) : _table.OrderBy(keySelector);
    }
}