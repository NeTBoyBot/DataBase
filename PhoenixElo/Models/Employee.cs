using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Database.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string FIO { get; set; }

        public string Description { get; set; }
    }
}
