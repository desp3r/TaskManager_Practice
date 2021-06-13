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
    public class Worker
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public string Position { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public List<Task> Tasks { get; set; }

        public Worker(string name, string surname, string position, string phoneNumber)
        {
            this.Name = name;
            this.Surname = surname;
            this.Position = position;
            this.PhoneNumber = phoneNumber;
        }
    }
}
