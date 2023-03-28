// TaskContext.cs
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model;
using RedditFullStack.models;

namespace RedditFullStack_main.model
{
public class TaskContext : DbContext
{
    public DbSet<TodoTask> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts {get; set;}
    public DbSet<Comment> Comments {get; set;}
    public string DbPath { get; }

    public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
    {
          DbPath = " bin/TodoTask.db";
    }
//Grunden til DbPath er så lang, var jeg havde et "couldnt create taskcontext object". aka kunne ikke finde db path fordi den ikke var absolut og kun releativ 

      public TaskContext()
        {
          DbPath = " bin/TodoTask.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>().ToTable("Tasks");
            modelBuilder.Entity<Post>().ToTable("Post");


        }
}
}
