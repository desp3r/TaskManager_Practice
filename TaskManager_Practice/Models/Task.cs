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

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int WorkerId { get; set; }
        
        public Worker Worker { get; set; }
        
        public int PtojectId { get; set; }
        
        public Project Project { get; set; }

        public Task(string name, string endTime, Worker worker, Project project)
        {
            this.Name = name;
            this.StartTime = DateTime.Now.ToString();
            this.EndTime = DateTime.Parse(endTime).ToString();
            this.Worker = worker;
            this.Project = project;
        }
        

    }
}