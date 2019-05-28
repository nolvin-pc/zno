using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZnoModelLibrary.Context;
using ZnoModelLibrary.EF;
using ZnoModelLibrary.Entities;
using ZnoModelLibrary.Interfaces;

namespace ZnoModelLibrary.Implementation
{
    public class GeneratedTestRepository : IGenericRepository<GeneratedTest>
    {
        private ApplicationDbContext _context;

        public GeneratedTestRepository(ApplicationDbContext applicationContext)
        {
            this._context = applicationContext;
        }
        
        public async Task Delete(object id)
        {
            var entity = await FindByIdAsync(id);

            if (entity is null)
                throw new ArgumentException("Generated Test with the specified ID not found!!!");

            _context.GeneratedTests.Remove(entity);
        }

        public async Task<IEnumerable<GeneratedTest>> Find(Expression<Func<GeneratedTest, bool>> predicate)
        {
            return await _context.GeneratedTests.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<GeneratedTest>> FindAll()
        {
            return await _context.GeneratedTests.ToListAsync();
        }
        
        public async Task<GeneratedTest> FindByIdAsync(object id)
        {
            return await _context.GeneratedTests.FirstOrDefaultAsync(s => s.Id == (int)id);
        }

        public async Task InsertAsync(GeneratedTest entity)
        {
            await _context.GeneratedTests.AddAsync(entity);
        }

        public async Task UpdateAsync(GeneratedTest entityToUpdate)
        {
            var entity = await FindByIdAsync(entityToUpdate.Id);

            if (entity is null)
                throw new ArgumentException("Generated Test with the specified ID not found!!!");

            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
