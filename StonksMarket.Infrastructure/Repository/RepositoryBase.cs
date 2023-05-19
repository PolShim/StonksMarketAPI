using Microsoft.EntityFrameworkCore;
using StonksMarket.Core.Repository;
using StonksMarket.Core.StonksDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly StonksDbContext _context;

        public RepositoryBase(StonksDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task<T> Update(T entity)
        {
            var result = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
