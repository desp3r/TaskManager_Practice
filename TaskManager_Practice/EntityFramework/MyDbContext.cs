using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using TaskManager_Practice.Infrastructure;
using TaskManager_Practice.Models;
using TaskManager_Practice.Models.Validators;
using TaskManager_Practice.Services;
using static TaskManager_Practice.Services.Common.Utils;

namespace TaskManager_Practice.EntityFramework
{
    public class MyDbContext : DbContext
    {
        private readonly ProjectValidator _projectValidator = new();
        private readonly TaskValidator _taskValidator = new();
        private readonly WorkerValidator _workerValidator = new();


        public Result AddProject(string name, DateTime deadline)
        {
            NotNull(name, nameof(name));
            NotNull(deadline, nameof(deadline));

            Project project = new Project() {Name = name, Deadline = deadline};

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
            NotNull(name, nameof(name));
            NotNull(endTime, nameof(endTime));
            NotNull(worker, nameof(worker));
            NotNull(project, nameof(project));

            //Task task = new(name, endTime, worker, project);

            Task task = new Task() { Name = name, StartTime = DateTime.Now, EndTime = endTime, Worker = worker, Project = project };

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
            NotNull(name, nameof(name));
            NotNull(surname, nameof(surname));
            NotNull(position, nameof(position));
            NotNull(phoneNumber, nameof(phoneNumber));

            Worker worker = new Worker()
                {Name = name, Surname = surname, Position = position, PhoneNumber = phoneNumber};
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

        public Result EditProject(Project project, string name, DateTime deadline)
        {
            NotNull(project, nameof(project));
            NotNull(name, nameof(name));
            NotNull(deadline, nameof(deadline));
            
            var temp = Projects.FirstOrDefault(p => p.Id == project.Id);

            if (temp == null)
                return Result.Error;

            temp.Name = name;
            temp.Deadline = deadline;
            
            var result = _projectValidator.Validate(temp);

            if (!result.IsValid)
            {
                Logger.WriteWarning(string.Join(',', result.Errors));
                return Result.Error;
            }
            Entry(temp).State = EntityState.Modified;
            SaveChanges();
            return Result.Ok;
        }
        
        public Result EditTask(Task task, string name, DateTime endTime, Worker worker, Project project)
        {
            NotNull(task, nameof(task));
            NotNull(name, nameof(name));
            NotNull(endTime, nameof(endTime));
            NotNull(worker, nameof(worker));
            NotNull(project, nameof(project));

            
            var temp = Tasks.FirstOrDefault(t => t.Id == task.Id);

            if (temp == null)
                return Result.Error;

            temp.Name = name;
            temp.EndTime = endTime;
            temp.Worker = worker;
            temp.Project = project;
            
            var result = _taskValidator.Validate(temp);

            if (!result.IsValid)
            {
                Logger.WriteWarning(string.Join(',', result.Errors));
                return Result.Error;
            }
            Entry(temp).State = EntityState.Modified;
            SaveChanges();
            return Result.Ok;
        }
        
        public Result EditWorker(Worker worker, string name, string surname, string position, string phoneNumber)
        {
            NotNull(worker, nameof(worker));
            NotNull(name, nameof(name));
            NotNull(surname, nameof(surname));
            NotNull(position, nameof(position));
            NotNull(phoneNumber, nameof(phoneNumber));
            
            var temp = Workers.FirstOrDefault(w => w.Id == worker.Id);

            if (temp == null)
                return Result.Error;

            temp.Name = name;
            temp.Surname = surname;
            temp.Position = position;
            temp.PhoneNumber = phoneNumber;
            
            var result = _workerValidator.Validate(temp);

            if (!result.IsValid)
            {
                Logger.WriteWarning(string.Join(',', result.Errors));
                return Result.Error;
            }
            Entry(temp).State = EntityState.Modified;
            SaveChanges();
            return Result.Ok;
        }

        public void RemoveProject(Project project)
        {
            Projects.Remove(project);
            SaveChanges();
        }
        
        public void RemoveTask(Task task)
        {
            Tasks.Remove(task);
            SaveChanges();
        }

        public void RemoveWorker(Worker worker)
        {
            Workers.Remove(worker);
            SaveChanges();
        }

        public void RemoveProjects()
        {
            var list = Projects.ToList();
            for (var i = list.Count - 1; i >= 0; i--)
                Projects.Remove(list[i]);
        }
        
        public void RemoveTasks()
        {
            var list = Workers.ToList();
            for (var i = list.Count - 1; i >= 0; i--)
                Workers.Remove(list[i]);
        }
                
        public void RemoveWorkers()
        {
            var list = Workers.ToList();
            for (var i = list.Count - 1; i >= 0; i--)
                Workers.Remove(list[i]);
        }

        public Project SelectProjectByName(string name)
        {
            Project temp = Projects.FirstOrDefault(p => p.Name == name);
            return temp;
        }

        public Worker SelectWorkerBySurname(String surnname)
        {
            Worker temp = Workers.FirstOrDefault(w => w.Surname == surnname);
            return temp;
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