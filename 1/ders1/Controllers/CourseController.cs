using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ders1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ders1.Controllers
{
    public class CourseController : Controller
    {


        public IActionResult Index()
        {

            return View(Repository.Courses[0]);
        }
        public IActionResult List()

        {


            return View(Repository.Courses);
        }

        public IActionResult Details(int id)

        {
            
            var course = Repository.GetCourseById(id);

            return View(course?? new Course { Id = 0, Title = "Course Not Found", Image = "notfound.jpg" });
        }
        
    }
}