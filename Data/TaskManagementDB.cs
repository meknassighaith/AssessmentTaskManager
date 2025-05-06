using Microsoft.EntityFrameworkCore;
using System;
using TaskManagementAPI.Models.TaskToDo;
using TaskManagementAPI.Models.User;
using TaskManagementAPI.Repositories.Interfaces;

namespace TaskManagementAPI.Data;

public class TaskManagementDB(DbContextOptions<TaskManagementDB> options) : DbContext(options), IUnitOfWork
{
    public DbSet<TaskToDo> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureTaskToDoEntity(modelBuilder);
        ConfigureUserEntity(modelBuilder);
    
        SeedDatabase(modelBuilder);

        base.OnModelCreating(modelBuilder);
        }

    private static void SeedDatabase(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<TaskToDo>().HasData(
                new TaskToDo { Id = 1, Title = "Task 1", Description = "Description task1", Status = TStatus.Open, AssignedUserId = 1 },
                new TaskToDo { Id = 2, Title = "Task 2", Description = "Description task2", Status = TStatus.InProgress, AssignedUserId = 2 },
                new TaskToDo { Id = 3, Title = "Task 3", Description = "Description task3", Status = TStatus.Closed, AssignedUserId = 1 }
            );
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", Role = UserRole.Admin, Password = "admin123" },
            new User { Id = 2, Username = "test", Role = UserRole.User, Password = "test" }
        );
    }

    private static void ConfigureUserEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Role)
            .HasConversion(
                v => v.ToString(),
                v => (UserRole)Enum.Parse(typeof(UserRole), v)
            )
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
    }

    private static void ConfigureTaskToDoEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskToDo>().HasKey(t => t.Id);
        modelBuilder.Entity<TaskToDo>().Property(t => t.Title).IsRequired();
        modelBuilder.Entity<TaskToDo>().Property(t => t.Description).IsRequired(false);
        modelBuilder.Entity<TaskToDo>().Property(t => t.Status)
            .HasConversion(
                v => v.ToString(),
                v => (TStatus)Enum.Parse(typeof(TStatus), v)
            )
            .IsRequired();
        modelBuilder.Entity<TaskToDo>().Property(t => t.AssignedUserId).IsRequired();
        
    }
}

