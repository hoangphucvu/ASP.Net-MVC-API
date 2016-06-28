using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace KMS.EmployeeManagement.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=EmployeeDB")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // define primary key
            modelBuilder.Entity<Employee>().HasKey(k => k.ID);
            // auto increment
            modelBuilder.Entity<Employee>().Property(k => k.ID).
            HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }
    }
}