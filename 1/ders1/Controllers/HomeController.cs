using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ders1.Models;

namespace ders1.Controllers;

public class HomeController : Controller
{
    
    public IActionResult Index()
    {
        var courses= Repository.Courses;
        

        return View(courses);
    }

    public IActionResult Contact()
    {
        return View();
    }

}
