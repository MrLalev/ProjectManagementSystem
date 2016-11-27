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

            context.Departments.AddOrUpdate(
              d => d.Name,
              new Department() { Name = "Softuer Development", Description = ""}
            );

            context.Teams.AddOrUpdate(
              t => t.Name,
              new Team() { Name = "2Slow2Curious", DepartmentId = 1 }
            );

            context.Positions.AddOrUpdate(
              p => p.Name,
              new Position() { Name = "Softuer Developer", Salary = 2000 }
            );

            context.Employees.AddOrUpdate(
              u => u.Email,
              new Employee() { Email = "admin@admin.com", FirstName = "Admin",SecondName = "Admin", LastName = "Admin", Password = "admin", Adress = "adress", Phone = "0000000000", AdminRole = true, DateofBirth = DateTime.Now, PositionId = 1, TeamId = 1 }
            );

            context.Projects.AddOrUpdate(
              p => p.Name,
              new Project() { Name = "BollywoodMovies", TeamId = 1, StartDate = DateTime.Now , EndDate = DateTime.Now.AddDays(5), Finished = false}
            );

            context.Tasks.AddOrUpdate(
              t => t.Title,
              new Task() { Title = "Make API", ProjectId = 1, CreatorId = 1, Description = "As a user I want to list/create/edit/delete movies from database.", Status = "New", PercentageDone = 0 }
            );
        }
    }
}
