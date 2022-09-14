using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixElo
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }

        public ApplicationDBContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=COMPUTER\SQLEXPRESS;Database=PhoenixElos11;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Motorcycle>().HasData(new Motorcycle
            {
                ID = 1,
                Name = "Yamaha R1",
                MaxSpeed = 320,
                Price = 138131

            });
        }
        public async Task Create(Motorcycle entity)
        {
            await Motorcycles.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task<bool> Delete(Motorcycle entity)
        {
            Remove(entity);
            await SaveChangesAsync();
            return true;
        }

        public IQueryable<Motorcycle> GetAll()
        {
            return Motorcycles;
        }

        public async Task<Motorcycle> Update(Motorcycle entity)
        {
            await Update(entity);
            await SaveChangesAsync();

            return entity;
        }
    }
}
