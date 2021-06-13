using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.EntityFramework
{
    public class MyDbContext : DbContext
    {

        public void AddProject(string name, string deadline)
        {
            Project project = new Project(name, deadline);
            Projects.Add(project);
            SaveChanges();
        }
        
        public void AddTask(string name, string endTime, Worker worker, Project project)
        {
            Task task = new Task(name, endTime, worker, project);
            Tasks.Add(task);
            SaveChanges();
        }
        
        public void AddWorker(string name, string surname, string position, string phoneNumber)
        {
            Worker worker = new Worker(name, surname, position, phoneNumber);
            Workers.Add(worker);
            SaveChanges();
        }
        
        public void EditProject(Project project, string name, string deadline)
        {
            var temp = Projects.FirstOrDefault(p => p.Id == project.Id);

            if (temp == null)
                return;

            temp.Name = name;
            temp.Deadline = DateTime.Parse(deadline).ToString();

            Entry(temp).State = EntityState.Modified;

            SaveChanges();
        }
        
        
        
        
        public void RemoveProject(Project project)
        {
            Projects.Remove(project);
        }
        
        
        public void RemoveWorkers()
        {
            var list = Workers.ToList();
            for (var i = list.Count - 1; i >= 0; i--)
                Workers.Remove(list[i]);
        }
        
        public void RemoveProjects()
        {
            var list = Projects.ToList();
            for (var i = list.Count - 1; i >= 0; i--)
                Projects.Remove(list[i]);
        }




        // работает
 


        // public List<Worker> GetWorkers()
        // {
        //     if (Workers.Count() == 0)
        //         return new List<Worker>();
        //
        //     return Workers.Include(a => a.Projects).ToList();
        //
        // }


        // public List<string> GetWorkersName()
        // {
        //     List<string> list = new List<string>();
        //     var query = "SELECT Name FROM Workers";
        //     using var connection = new SqliteConnection("Filename=myDb.db");
        //     connection.Open();
        //     using var command = new SqliteCommand(query,connection);
        //     using var reader = command.ExecuteReader();
        //     while (reader.Read())
        //     {
        //         list.Add(reader.GetString(0));
        //     }
        //
        //     return list;
        //
        // }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<Worker>()
        //     .HasIndex(u => u.Name)
        //     .IsUnique();
        // }



        public DbSet<Project> Projects { get; set; }
        
        public DbSet<Task> Tasks { get; set; }
        
        public DbSet<Worker> Workers { get; set; }
        
        


        public MyDbContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Filename=myDb.db");
  
    }
}