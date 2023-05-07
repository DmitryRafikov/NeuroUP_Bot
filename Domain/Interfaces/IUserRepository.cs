using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    interface IUserRepository: IRepository<UserEntity>
    {
        Task<UserEntity> GetById(int id);
        Task<UserEntity> GetByChatId(long chatId);
    }
}
