using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    internal class ExersizeRepository : IExersizeRepository
    {
        private readonly DataContext _dataContext;
        public ExersizeRepository() {
            _dataContext = new DataContext();
        }
        public async Task<bool> Add(ExersizeEntity entity)
        {
            var exersize = await _dataContext.Exersizes.OrderBy(x => x.Id)
                                                .FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (exersize != null)
                return false;
            await _dataContext.Exersizes.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<ExersizeEntity>> GetAll()
        {
            return Task.FromResult((IEnumerable<ExersizeEntity>)_dataContext.Exersizes.OrderBy(x => x.Id));
        }

        public async Task<ExersizeEntity> GetById(int id)
        {
            var exersize = await _dataContext.Exersizes.OrderBy(x => x.Id)
                                               .FirstOrDefaultAsync(e => e.Id == id);
            if (exersize == null)
                throw new NullReferenceException("ExersizeRepository: GetById(int Id)");
            return exersize;
        }

        public async Task<bool> Remove(ExersizeEntity entity)
        {
            var exersize = await _dataContext.Exersizes.OrderBy(x => x.Id)
                                              .FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (exersize == null)
                return false;
            _dataContext.Exersizes.Remove(exersize);
            return true;
        }

        public Task<bool> Update(ExersizeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
