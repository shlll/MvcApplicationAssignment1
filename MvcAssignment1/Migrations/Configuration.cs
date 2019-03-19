namespace MvcAssignment1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MvcAssignment1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcAssignment1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcAssignment1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            if (!context.Roles.Any(p => p.Name == "Users"))
            {
                roleManager.Create(new IdentityRole { Name = "Users" });
            }
            if (!context.Roles.Any(p => p.Name == "Courses"))
            {
                roleManager.Create(new IdentityRole { Name = "Courses" });
            }

            ApplicationUser user1;
            if (!context.Users.Any(
                p => p.UserName == "johndoe@test.com"))
            {
                user1 = new ApplicationUser();
                user1.FirstName = "John";
                user1.LastName = "Doe";
                user1.UserName = "johndoe@test.com";
                user1.Email = "johndoe@test.com";
                userManager.Create(user1, "Password-1");
            }
            else
            {
                user1 = context
                    .Users
                    .First(p => p.UserName == "johndoe@test.com");
            }
            if (!userManager.IsInRole(user1.Id, "Users"))
            {
                userManager.AddToRole(user1.Id, "Users");
            }
            ApplicationUser user2;
            if (!context.Users.Any(
                p => p.UserName == "johndoe@test.com"))
            {
                user2 = new ApplicationUser();
                user2.FirstName = "Jane";
                user2.LastName = "Doe";
                user2.UserName = "janedoe@test.com";
                user2.Email = "janedoe@test.com";
                userManager.Create(user2, "Password-1");
            }
            else
            {
                user2 = context
                    .Users
                    .First(p => p.UserName == "janedoe@test.com");
            }
            if (!userManager.IsInRole(user2.Id, "Users"))
            {
                userManager.AddToRole(user2.Id, "Users");
            }
            Course name1;
            if (!context.Courses.Any(
               p => p.Name == "John"))
            {
                name1 = new Course();
                name1.Name = "softwaredeveloper,cyberdefense";
                name1.NumberOfHours = 670;
                userManager.Create(user1, "Password-1");
            }
            else
            {
                name1 = context
                    .Courses
                    .First(p => p.Name == "John");
            }
            if (!userManager.IsInRole(name1.Name, "Courses"))
            {
                userManager.AddToRole(name1.Name, "Courses");
            }
            Course name2;
            if (!context.Courses.Any(
               p => p.Name == "Jane"))
            {
                name2 = new Course();
                name2.Name = "softwaredeveloper";
                name2.NumberOfHours = 330;
                userManager.Create(user2, "Password-1");
            }
            else
            {
                name2 = context
                    .Courses
                    .First(p => p.Name == "Jane");
            }
            if (!userManager.IsInRole(name2.Name, "Courses"))
            {
                userManager.AddToRole(name2.Name, "Courses");
            }

        }
    }
}
