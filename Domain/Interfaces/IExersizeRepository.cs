using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    interface IExersizeRepository: IRepository<ExersizeEntity>
    {
        Task<ExersizeEntity> GetById(int id);
    }
}
