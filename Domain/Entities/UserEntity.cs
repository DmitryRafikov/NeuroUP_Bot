using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class UserEntity
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public string? Username { get; set; }
        public int CurrentState { get; set; }
        public int ExersizeNumber { get; set; }

    }
}
