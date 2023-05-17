using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Database.Models
{
    public class Request
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Content { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? CompleteTime { get; set; }

        public bool IsCompleted { get; set; }
    }
}
