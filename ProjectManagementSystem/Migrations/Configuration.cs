namespace ProjectManagementSystem.Migrations
{
    using DataAccess.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagementSystem.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectManagementSystem.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Employees.AddOrUpdate(
              u => u.Email,
              new Employee() { Email = "admin@admin.com", FirstName = "Admin",SecondName = "Admin", LastName = "Admin", Password = "admin", Adress = "adress", Phone = "0000000000", AdminRole = true, DateofBirth = DateTime.Now,  }
            );
        }
    }
}
