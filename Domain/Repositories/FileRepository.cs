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
    class FileRepository : IFileRepository
    {
        private DataContext _dataContext;
        public FileRepository()
        {
            _dataContext = new DataContext();
        }

        public async Task<bool> Add(FileEntity entity)
        {
            var file = await _dataContext.Files.OrderBy(x => x.Id)
                                               .FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (file != null)
                return false;
            await _dataContext.Files.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<FileEntity>> GetAll()
        {
            return Task.FromResult((IEnumerable<FileEntity>)_dataContext.Files.OrderBy(x => x.Id));
        }

        public async Task<FileEntity> GetById(int id)
        {
            var file = await _dataContext.Files.OrderBy(x => x.Id)
                                                .FirstOrDefaultAsync(e => e.Id == id);
            if (file == null)
                throw new NullReferenceException("FileRepository: GetById(int Id)");
            return file;
        }

        public async Task<bool> Remove(FileEntity entity)
        {
            var file = await _dataContext.Files.OrderBy(x => x.Id)
                                              .FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (file == null)
                return false;
            _dataContext.Files.Remove(file);
            return true;
        }

        public Task<bool> Update(FileEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
