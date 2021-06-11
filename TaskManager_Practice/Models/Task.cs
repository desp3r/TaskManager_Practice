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
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public DateTime Deadline { get; set; }

        [Required] public String Status { get; set; }
        
        public Worker Worker { get; set; }

        public Task()
        {
        }

        public Task(string name, string time) // вопрос как инициализировать через enum Statuses
        {
            this.Name = name;
            this.Deadline = DateTime.Parse(time);
        }
    }
}