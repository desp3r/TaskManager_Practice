using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Practice.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public DateTime Deadline { get; set; }

        public List<Task> Tasks { get; set; }

        public Project(string name, DateTime deadline)
        {
            Name = name;
            Deadline = deadline;
        }
    }
}
