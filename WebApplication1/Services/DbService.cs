using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public abstract class DbService<T> where T: class, IDbItem
    {
        protected readonly DatabaseContext _db;


        public DbService(DatabaseContext db)
        {
            _db = db;
        }


        protected abstract DbSet<T> DbSet { get; }


        public async Task<T> AddItem(T item)
        {
            item.ClearNavigationProperties();
            await DbSet.AddAsync(item);
            return await FindItem(item.Id);
        }

        public Task<T> FindItem(int id)
        {
            return IncludeProperties(DbSet.AsNoTracking())
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<T> UpdateItem(T item)
        {
            var entity = await DbSet.FindAsync(item.Id);
            var entry = _db.Entry(entity);

            entry.CurrentValues.SetValues(item);
            entry.State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return await FindItem(item.Id);
        }


        protected abstract IQueryable<T> IncludeProperties(IQueryable<T> query);
    }
}

