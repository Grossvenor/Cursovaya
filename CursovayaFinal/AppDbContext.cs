using CursovayaFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace CursovayaFinal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role userRole = new Role { Id = 1, Name = "User" };
            Role adminRole = new Role { Id = 2, Name = "Admin" };

            User admin = new User { Id = 1, Name = "Admin", Surname = "Admin", Login = "aaa", Password = "aaa", RoleId = adminRole.Id };

            EventCondition PastCondition = new EventCondition { Id = 1, Name = "Past" };
            EventCondition CurrentCondition = new EventCondition { Id = 2, Name = "Current" };
            EventCondition FutureCondition = new EventCondition { Id = 3, Name = "Futuret" };

            Section CultSection = new Section { Id = 1, Name = "Культурный Сектор" };
            Section RedColleg = new Section { Id = 2, Name = "Ред.Коллегия" };
            Section SportSection = new Section { Id = 3, Name = "Спортивный Сектор" };

            //DUevent NationalKitchen = new DUevent { Id = 1, Name = "Кухня народов", Description = "Обзор еды оч вкусно" };


            modelBuilder.Entity<EventCondition>().HasData(PastCondition, CurrentCondition, FutureCondition);
            modelBuilder.Entity<Section>().HasData(CultSection, RedColleg, SportSection);
            //modelBuilder.Entity<DUevent>().HasData(NationalKitchen);
            modelBuilder.Entity<User>().HasData(admin);
            modelBuilder.Entity<Role>().HasData(userRole, adminRole);

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<DUevent> Events { get; set; }
        public DbSet<EventCondition> Conditions { get; set; }


    }
}
