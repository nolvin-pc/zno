using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZnoModelLibrary.EF;
using ZnoModelLibrary.Entities;
using ZnoModelLibrary.Interfaces;

namespace ZnoModelLibrary.Implementation
{
    public class UserAnswerRepository : IGenericRepository<UserAnswer>
    {
        private ApplicationContext _context;

        public UserAnswerRepository(ApplicationContext applicationContext)
        {
            this._context = applicationContext;
        }

        public async Task Delete(object id)
        {
            var entity = await FindByIdAsync(id);

            if (entity is null)
                throw new ArgumentException("User answer with the specified ID not found!!!");

            _context.UserAnswers.Remove(entity);
        }

        public async Task<IEnumerable<UserAnswer>> Find(Expression<Func<UserAnswer, bool>> predicate)
        {
            return await _context.UserAnswers.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<UserAnswer>> FindAll()
        {
            return await _context.UserAnswers.ToListAsync();
        }

        public async Task<UserAnswer> FindByIdAsync(object id)
        {
            return await _context.UserAnswers.Where(t => t.Id == (int)id).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(UserAnswer entity)
        {
            await _context.UserAnswers.AddAsync(entity);
        }

        public async Task UpdateAsync(UserAnswer entityToUpdate)
        {
            var entity = await FindByIdAsync(entityToUpdate.Id);

            if (entity is null)
                throw new ArgumentException("User answer with the specified ID not found!!!");

            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
