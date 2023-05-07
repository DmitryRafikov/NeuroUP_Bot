using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    internal class AdminRepository : IAdminRepository
    {
        private DataContext _dataContext;
        public AdminRepository()
        {
            _dataContext = new DataContext();
        }
        public async Task<bool> Add(AdminEntity entity)
        {
            var admin = await _dataContext.Admins.OrderBy(x => x.Id)
                                               .FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (admin != null)
                return false;
            await _dataContext.Admins.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<AdminEntity>> GetAll()
        {
            return Task.FromResult((IEnumerable<AdminEntity>)_dataContext.Admins.OrderBy(x => x.Id));
        }

        public async Task<AdminEntity> GetByChatId(long chatId)
        {
            var admin = await _dataContext.Admins.OrderBy(x => x.Id)
                                               .FirstOrDefaultAsync(e => e.ChatId == chatId);
            if (admin == null)
                throw new NullReferenceException("AdminRepository: GetByChatId(long ChatId)");
            return admin;
        }

        public async Task<AdminEntity> GetById(int id)
        {
            var admin = await _dataContext.Admins.OrderBy(x => x.Id)
                                               .FirstOrDefaultAsync(e => e.Id == id);
            if (admin == null)
                throw new NullReferenceException("AdminRepository: GetById(int Id)");
            return admin;
        }

        public async Task<bool> Remove(AdminEntity entity)
        {
            var admin = await _dataContext.Admins.OrderBy(x => x.Id)
                                              .FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (admin == null)
                return false;
            _dataContext.Admins.Remove(admin);
            return true;
        }

        public Task<bool> Update(AdminEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
