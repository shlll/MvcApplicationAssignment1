using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAssignment1.Models
{
    public class Details
    {
        public Details()
        {
            Users = new List<ApplicationUser>();
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string CourseName { get; set; }
        public int NumberOfHours { get; set; }
        public int NumberOfEnrollments { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<Course> Courses { get; set; }
        public string CoursesId { get; set; }
    }
}