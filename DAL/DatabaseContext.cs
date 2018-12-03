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

        public DbSet<Mark> Marks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ParentAccount> ParentAccounts { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherAccount> TeacherAccounts { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        
    }
}
