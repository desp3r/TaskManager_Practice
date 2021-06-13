using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TaskManager_Practice.Infrastructure;
using TaskManager_Practice.Models;
using TaskManager_Practice.Models.Validators;
using TaskManager_Practice.Services;

namespace TaskManager_Practice.EntityFramework
{
    public class MyDbContext : DbContext
    {
        private ProjectValidator _projectValidator = new();
        private TaskValidator _taskValidator = new();
        private WorkerValidator _workerValidator = new();


        public Result AddProject(string name, DateTime deadline)
        {
            Project project = new(name, deadline);


            var result = _projectValidator.Validate(project);

            if (!result.IsValid)
            {
                Logger.WriteWarning(string.Join(',', result.Errors));
                return Result.Error;
            }
            Projects.Add(project);
            SaveChanges();
            return Result.Ok;

        }

        public Result AddTask(string name, DateTime endTime, Worker worker, Project project)
        {
            Task task = new(name, endTime, worker, project);

            var result = _taskValidator.Validate(task);
            if (!result.IsValid)
            {
                Logger.WriteWarning(string.Join(',', result.Errors));
                return Result.Error;
            }
            Tasks.Add(task);
            SaveChanges();
            return Result.Ok;
        }

        public Result AddWorker(string name, string surname, string position, string phoneNumber)
        {
            Worker worker = new Worker(name, surname, position, phoneNumber);
            var result = _workerValidator.Validate(worker);
            if (!result.IsValid)
            {
                Logger.WriteWarning(string.Join(',', result.Errors));
                return Result.Error;
            }
            Workers.Add(worker);
            SaveChanges();
            return Result.Ok;
        }

        public void EditProject(Project project, string name, DateTime deadline)
        {
            var temp = Projects.FirstOrDefault(p => p.Id == project.Id);

            if (temp == null)
                return;

            temp.Name = name;
            temp.Deadline = deadline;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Filename=myDb.db");
    }
}