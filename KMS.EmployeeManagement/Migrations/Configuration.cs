namespace KMS.EmployeeManagement.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KMS.EmployeeManagement.Models.EmployeeContext>
    {
        private readonly bool pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "KMS.EmployeeManagement.Models.EmployeeContext";
            var migrator = new DbMigrator(this);
            pendingMigrations = migrator.GetPendingMigrations().Any();
        }

        protected override void Seed(KMS.EmployeeManagement.Models.EmployeeContext context)
        {
            //Exit if there aren't any pending migrations
            if (!pendingMigrations) return;

            //else run your code to seed the database, e.g.
            context.Employees.AddOrUpdate(
              e => e.ID,
              new Employee { FirstName = "Nguyen", MiddleName = "Van", LastName = "Anh", DOB = DateTime.Parse("1990-3-13"), Gender = false, StartDate = DateTime.Parse("2016-3-13") },
              new Employee { FirstName = "Nguyen", MiddleName = "Van", LastName = "Anh", DOB = DateTime.Parse("1990-3-13"), Gender = false, StartDate = DateTime.Parse("2016-3-13") },
              new Employee { FirstName = "Nguyen", MiddleName = "Van", LastName = "Anh", DOB = DateTime.Parse("1990-3-13"), Gender = false, StartDate = DateTime.Parse("2016-3-13") },
              new Employee { FirstName = "Nguyen", MiddleName = "Van", LastName = "Anh", DOB = DateTime.Parse("1990-3-13"), Gender = false, StartDate = DateTime.Parse("2016-3-13") },
              new Employee { FirstName = "Nguyen", MiddleName = "Van", LastName = "Anh", DOB = DateTime.Parse("1990-3-13"), Gender = false, StartDate = DateTime.Parse("2016-3-13") },
              new Employee { FirstName = "Nguyen", MiddleName = "Van", LastName = "Anh", DOB = DateTime.Parse("1990-3-13"), Gender = false, StartDate = DateTime.Parse("2016-3-13") },
              new Employee { FirstName = "Nguyen", MiddleName = "Van", LastName = "Anh", DOB = DateTime.Parse("1990-3-13"), Gender = false, StartDate = DateTime.Parse("2016-3-13") }
            );
        }
    }
}