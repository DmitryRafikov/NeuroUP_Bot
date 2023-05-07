using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Domain
{
    internal class DataContext:DbContext
    {
        public string DbPath;
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<ExersizeEntity> Exersizes { get; set; }
        public DbSet<FileEntity> Files { get; set; }
        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "BasketStoreTelegramDB.db");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        ~DataContext()
        {
            Dispose();
        }
    }
}
