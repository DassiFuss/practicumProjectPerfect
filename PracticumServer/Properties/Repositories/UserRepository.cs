using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Properties.Entities;
using Properties.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Repositories
{
    public class UserRepository:IDataRepository<User>
    {
        IContext _context;
        public UserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User entity)
        {

            EntityEntry<User> newOne = _context.users.Add(entity);

            await _context.SaveChangesAsync();
            return newOne.Entity;
        }

        public async Task DeleteAsync(string id)
        {
            _context.users.Remove(_context.users.FirstOrDefault(p => p.Id == id));
            await _context.SaveChangesAsync();

        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.users.FirstOrDefaultAsync(d => d.Id == id);
        }

 
    }
}
