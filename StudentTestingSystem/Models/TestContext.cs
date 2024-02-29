using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    class TestContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }


        public TestContext() 
        {
            if(Database == null)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
                TestData.DataTest(this);
            }
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
