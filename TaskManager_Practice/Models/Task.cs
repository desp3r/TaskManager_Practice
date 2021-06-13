using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Practice.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int WorkerId { get; set; }
        
        public Worker Worker { get; set; }
        
        public int PtojectId { get; set; }
        
        public Project Project { get; set; }

    }
}