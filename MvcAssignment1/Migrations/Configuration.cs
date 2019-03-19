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
            var userManager =
            new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            ApplicationUser johnDoe;
            ApplicationUser janeDoe;
            Course softwareDeveloperCourse;
            Course cyberDefenseCourse;
            Course nsDiplomaCourse;
            Details courseOne;
            Details courseTwo;
            Details courseThree;
            if (!context.Users.Any(p => p.UserName ==
            "johndoe@test.com"))
            {
                johnDoe = new ApplicationUser();
                johnDoe.FirstName = "John";
                johnDoe.LastName = "Doe";
                johnDoe.Email = "johndoe@test.com";
                johnDoe.UserName = "johndoe@test.com";

                userManager.Create(johnDoe, "Password-1");
            }
            else
            {
                johnDoe = context.Users.First(p =>
                p.UserName == "johndoe@test.com");
            }

            if (!context.Users.Any(p => p.UserName ==
            "janedoe@test.com"))
            {
                janeDoe = new ApplicationUser();
                janeDoe.FirstName = "Jane";
                janeDoe.LastName = "Doe";
                janeDoe.Email = "janedoe@test.com";
                janeDoe.UserName = "janedoe@test.com";

                userManager.Create(janeDoe, "Password-1");
            }
            else
            {
                janeDoe = context.Users.First(p =>
                p.UserName == "janedoe@test.com");
            }

            if (!context.Courses.Any(p =>
                p.Name == "Software Developer"))
            {
                softwareDeveloperCourse = new Course();
                courseOne = new Details();
                softwareDeveloperCourse.Name = "Software Developer";
                softwareDeveloperCourse.NumberOfHours = 330;
                softwareDeveloperCourse.NumberOfEnrollments = 2;
                softwareDeveloperCourse.DetailId = courseOne.CoursesId;
                context.Courses.Add(softwareDeveloperCourse);
            }
            else
            {
                softwareDeveloperCourse = context.Courses.First(p =>
                p.Name == "Software Developer");
            }

            if (!context.Courses.Any(p =>
                p.Name == "Cyber Defense"))
            {
                cyberDefenseCourse = new Course();
                courseTwo = new Details();
                cyberDefenseCourse.Name = "Cyber Defense";
                cyberDefenseCourse.NumberOfHours = 340;
                cyberDefenseCourse.NumberOfEnrollments = 1;
                cyberDefenseCourse.DetailId = courseTwo.CoursesId;
                context.Courses.Add(cyberDefenseCourse);
            }
            else
            {
                cyberDefenseCourse = context.Courses
                    .First(p => p.Name == "Cyber Defense");
            }
            if (!context.Courses.Any(p =>
                p.Name == "Network Security Diploma"))
            {
                nsDiplomaCourse = new Course();
                courseThree = new Details();
                nsDiplomaCourse.Name = "Network Security Diploma";
                nsDiplomaCourse.NumberOfHours = 400;
                nsDiplomaCourse.NumberOfEnrollments = 0;
                nsDiplomaCourse.DetailId = courseThree.CoursesId;
                context.Courses.Add(nsDiplomaCourse);
            }
            else
            {
                nsDiplomaCourse = context.Courses
                    .First(p => p.Name == "Network Security Diploma");
            }
            if (!context.Detail.Any(p =>
            p.CourseName == "Software Developer"))
            {
                courseOne = new Details();
                courseOne.CourseName = "Software Developer";
                courseOne.NumberOfHours = 330;
                courseOne.NumberOfEnrollments = 2;
                courseOne.PersonName = "JohnDoe";
                context.Detail.Add(courseOne);
            }
            else
            {
                courseOne = context.Detail
                    .First(p => p.CourseName == "Software Developer");
            }
            if (!context.Detail.Any(p =>
           p.CourseName == "Cyber Defense"))
            {
                courseTwo = new Details();
                courseTwo.CourseName = "Cyber Defense";
                courseTwo.NumberOfHours = 340;
                courseTwo.NumberOfEnrollments = 1;
                courseTwo.PersonName = "JaneDoe";
                context.Detail.Add(courseTwo);
            }
            else
            {
                courseTwo = context.Detail
                    .First(p => p.CourseName == "Cyber Defense");
            }
            if (!context.Detail.Any(p =>
           p.CourseName == "Network Security Diploma"))
            {
                courseThree = new Details();
                courseThree.CourseName = "Network Security Diploma";
                courseThree.NumberOfHours = 400;
                courseThree.NumberOfEnrollments = 0;
                courseThree.PersonName = "";
                context.Detail.Add(courseThree);
            }
            else
            {
                courseThree = context.Detail
                    .First(p => p.CourseName == "Network Security Diploma");
            }

            context.SaveChanges();

            if (!johnDoe.Courses.Any())
            {
                johnDoe.Courses.Add(cyberDefenseCourse);
            }

            if (!janeDoe.Courses.Any())
            {
                janeDoe.Courses.Add(softwareDeveloperCourse);
                janeDoe.Courses.Add(cyberDefenseCourse);
            }

            context.SaveChanges();

        }
    }
}
