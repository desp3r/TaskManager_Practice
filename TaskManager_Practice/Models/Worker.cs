using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Practice.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public ICollection<Project> Projects;

        public Worker()
        {
            Projects = new List<Project>();
        }
        public Worker(string name, string surname):base()
        {
            Name = name;
            Surname = surname;
        }
    }
    
    
}
