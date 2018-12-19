using System;
using DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext : IdentityDbContext<UserAccount>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SchoolClass>().HasData(
                new SchoolClass() {Id= 100, Name = "1A"},
                new SchoolClass() {Id= 101,Name = "1B"},
                new SchoolClass() {Id= 102,Name = "1C"},
                new SchoolClass() {Id= 103,Name = "1D"},
                new SchoolClass() {Id= 104,Name = "2A"},
                new SchoolClass() {Id= 105,Name = "2B"},
                new SchoolClass() {Id= 106,Name = "2C"},
                new SchoolClass() {Id= 107,Name = "3A"},
                new SchoolClass() {Id= 108,Name = "3B"},
                new SchoolClass() {Id= 109,Name = "3C"},
                new SchoolClass() {Id= 110,Name = "3S"},
                new SchoolClass() {Id= 111,Name = "4A"},
                new SchoolClass() {Id= 112,Name = "4B"});
        }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ParentAccount> ParentAccounts { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherAccount> TeacherAccounts { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        
    }
}
