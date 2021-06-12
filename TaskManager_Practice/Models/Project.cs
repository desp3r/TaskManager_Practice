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
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Status { get; set; }

        [Required]
        public string StartTime { get; set; }
        
        [ForeignKey("Worker")]
        public int? WorkerId { get; set; }
        public Worker Worker { get; set; }

        public Project()
        {
        }

        public Project(string name)
        {
            this.Name = name;
            this.StartTime = DateTime.Now.ToString();
            this.Status = "In Process";
        }
    }
}
