using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository() { 
            _dataContext = new DataContext();
        }
        public async Task<bool> Add(UserEntity entity)
        {
            var user = await _dataContext.Users.OrderBy(x => x.Id)
                                                .FirstOrDefaultAsync(e=>e.Id == entity.Id);
            if(user != null)
                return false;
            await _dataContext.Users.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<UserEntity>> GetAll()
        {
            return Task.FromResult((IEnumerable<UserEntity>)_dataContext.Users.OrderBy(x => x.Id));
        }

        public async Task<UserEntity> GetByChatId(long chatId)
        {
            var user = await _dataContext.Users.OrderBy(x => x.Id)
                                               .FirstOrDefaultAsync(e => e.ChatId == chatId);
            if (user == null)
                throw new NullReferenceException("UserRepository: GetByChatId(long chatId)");
            return user;
        }

        public async Task<UserEntity> GetById(int id)
        {
            var user = await _dataContext.Users.OrderBy(x => x.Id)
                                               .FirstOrDefaultAsync(e => e.Id == id);
            if (user == null)
                throw new NullReferenceException("UserRepository: GetById(int chatId)");
            return user;
        }

        public async Task<bool> Remove(UserEntity entity)
        {
            var user = await _dataContext.Users.OrderBy(x => x.Id)
                                              .FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (user == null)
                return false;
            _dataContext.Users.Remove(user);
            return true;
        }

        public Task<bool> Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
