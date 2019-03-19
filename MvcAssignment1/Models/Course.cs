using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAssignment1.Models
{
    public class Course
    {
        public Course()
        {
            Users = new List<ApplicationUser>();
            Detail = new List<Details>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfHours { get; set; }
        public int NumberOfEnrollments { get; set; }
        public virtual List<Details> Detail { get; set; }
        public string DetailId { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }
    }
}