using Domain.Entities;

namespace Domain.Interfaces
{
    interface IAdminRepository:IRepository<AdminEntity>
    {
        Task<AdminEntity> GetById(int id);
        Task<AdminEntity> GetByChatId(long chatId);

    }
}
