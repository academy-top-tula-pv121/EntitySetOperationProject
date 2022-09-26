using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySetOperationProject
{
    public class Student
    {
        public int Id { set; get; }
        public string? Name { set; get; }
        public int Age { set; get; }
        public int GroupId { set; get; }
        public Group? Group { set; get; }

    }

    public class Group
    {
        public int Id { set; get; }
        public string? Title { set; get; }
        public List<Student>? Students { set; get; }

    }

    public class AppContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDb;Integrated Security=True");
        }
    }

}
