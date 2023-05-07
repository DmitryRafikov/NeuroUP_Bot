using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    interface IFileRepository:IRepository<FileEntity>
    {
        Task<FileEntity> GetById(int id);
    }
}
