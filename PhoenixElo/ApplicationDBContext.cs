using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WPF_Database.Models;

namespace PhoenixElo
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDBContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserID = Guid.NewGuid(),
                UserName = "Admin",
                Password = "Admin",
                Role = "Admin"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = Guid.NewGuid(),
                Description = "Преподаватель Ин. Языка",
                FIO = "Петров Игорь Викторович"
            }, new Employee
            {
                Id = Guid.NewGuid(),
                Description = "Преподаватель Русского Языка",
                FIO = "Сергеев Владислав Олегович"
            });
        }

        public async Task Create(Request entity)
        {
            await Requests.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task CreateUser(User entity)
        {
            await Users.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task<bool> Delete(Request entity)
        {   
            Remove(entity);
            await SaveChangesAsync();
            return true;
        }

        public IQueryable<Request> GetAll()
        {
            return Requests;
        }

        public async Task<Request> Update(Request entity)
        {
            Requests.Update(entity);
            await SaveChangesAsync();

            return entity;
        }
    }
}
