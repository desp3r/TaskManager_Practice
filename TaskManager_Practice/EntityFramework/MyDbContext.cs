﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.EntityFramework
{
    public class MyDbContext : DbContext
    {

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

        // public void DropData()
        // {
        //     this.Database.ExecuteSqlCommand("DROP TABLE Assignments");
        //     this.Database.ExecuteSqlCommand("DROP TABLE Categories");
        //     this.Database.ExecuteSqlCommand("DROP DATABASE myDb.db");
        // }


        /// <summary>
        /// Получение коллекции работяг
        /// </summary>
        /// <returns></returns>
        public List<Worker> GetWorkers()
        {
            if (Workers.Count() == 0)
                return new List<Worker>();

            return Workers.Include(a => a.Projects).ToList();

        }


        public List<string> GetWorkersName()
        {
            List<string> list = new List<string>();
            var query = "SELECT Name FROM Workers";
            using var connection = new SqliteConnection("Filename=myDb.db");
            connection.Open();
            using var command = new SqliteCommand(query,connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }

            return list;

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Worker>()
            .HasIndex(u => u.Name)
            .IsUnique();
        }



        public DbSet<Project> Projects { get; set; }
        public DbSet<Worker> Workers { get; set; }


        public MyDbContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Filename=myDb.db");
  
    }
}