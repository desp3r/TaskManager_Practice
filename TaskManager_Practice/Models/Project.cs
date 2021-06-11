using System;
using System.Collections;
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
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        // [Required] public string StartTime { get; }
        //
        // public string EndTime { get; set; }


        //
        // public string Status
        // {
        //     get
        //     {
        //         if (this.Deadline.CompareTo(DateTime.Now) > 0)
        //             return "Expired";
        //         else
        //             return "In Process";
        //     }
        // }
        //
        // public List<Task> Tasks { get; set; }
        //
        // public double Progress
        // {
        //     get
        //     {
        //         int done = 0;
        //         foreach (var item in Tasks)
        //         {
        //             if (item.Status == "Done")
        //                 done++;
        //         }
        //
        //         return (Tasks.Count / done);
        //     }
        // }


        public ICollection Workers { get; set; }
        
        
        
        [ForeignKey("Worker")] 
        public int? WorkerId { get; set; }
        public Worker Worker { get; set; }

        // public void AddTask(Task task)
        // {
        //     this.Tasks.Add(task);
        // }
        //
        // public void DeleteTask(Task task)
        // {
        //     if (this.Tasks.Contains(task))
        //     {
        //         this.Tasks.Remove(task);
        //     }
        // }

        // public void MarkAsDone()
        // {
        //     this.Status = "Done";
        // }

        public Project()
        {
        }

        public Project(string name)
        {
            this.Name = name;
            // this.StartTime = DateTime.Now.ToString();
            // this.EndTime = endTime;
        }
    }
}