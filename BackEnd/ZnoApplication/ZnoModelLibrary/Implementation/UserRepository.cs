using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZnoModelLibrary.Abstraction;
using ZnoModelLibrary.Context;
using ZnoModelLibrary.Entities;
using ZnoModelLibrary.Interfaces;

namespace ZnoModelLibrary.Implementation
{
    public class UserRepository : IGenericRepository<ApplicationUser>, IUserRepository<ApplicationUser>
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(object id)
        {
            var entity = await FindByIdAsync(id);

            if (entity is null)
                throw new ArgumentException("User with the specified ID not found!!!");

            _context.Users.Remove(entity);
        }

        public async Task<IEnumerable<ApplicationUser>> Find(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return await _context.Users.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> FindAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> FindByIdAsync(object id)
        {
            return await _context.Users.FirstOrDefaultAsync(t => t.Id.Equals(id.ToString()));
        }

        public async Task<ApplicationUser> FindByLogin(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(login) || u.PhoneNumber.Equals(login));
        }

        public async Task InsertAsync(ApplicationUser entity)
        {
            await _context.Users.AddAsync(entity);
        }

        public async Task UpdateAsync(ApplicationUser entityToUpdate)
        {
            var entity = await FindByIdAsync(entityToUpdate.Id);

            if (entity is null)
                throw new ArgumentException("User with the specified ID not found!!!");

            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}