using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSQLServerSetup.Models
{
    public class ToDo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsUrgent { get; set; } = false;
        public bool IsDone { get; set; } = false;
    }
}
