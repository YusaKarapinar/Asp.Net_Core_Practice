using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ders1.Models
{
    public class Repository
    {
        private static readonly List<Course> courses = new List<Course>
        {
            new Course { Id = 1, Title = "C# Basics", Image = "image1.jpg", Tags = new[] { "C#", "Programming" }, isActive = true, isHome = true },
            new Course { Id = 2, Title = "ASP.NET Core", Image = "image2.jpg", Tags = new[] { "ASP.NET", "Web Development" }, isActive = false, isHome = true },
            new Course { Id = 3, Title = "JavaScript Essentials", Image = "image3.jpg", Tags = new[] { "JavaScript", "Frontend" }, isActive = true, isHome = false }
        };
        public static List<Course> Courses
        {
            get { return courses; }
        }
        public static Course? GetCourseById(int id)
        {
            return courses.FirstOrDefault(c => c.Id == id);
        }
    }
}