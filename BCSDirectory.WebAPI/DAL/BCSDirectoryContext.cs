using BCSDirectory.Models;
using System.Data.Entity;

namespace BCSDirectory.WebAPI.DAL
{
    public class BCSDirectoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Department> Departments { get; set; }

        public BCSDirectoryContext() : base("BCSDirectoryDb")
        {

        }
    }
}