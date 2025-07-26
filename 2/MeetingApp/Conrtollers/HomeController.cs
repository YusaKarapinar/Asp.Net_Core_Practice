using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MeetingApp.Conrtollers
{
    public class HomeController : Controller
    {
      
      public IActionResult Index()
        {

            int saat = DateTime.Now.Hour;
           
            ViewBag.Selamlama = saat < 12 ? "İyi günler":"günaydın";
            int UserCount = Repository.Users.Where(u => u.WillAttend).Count();

            var meetingInfo= new Models.MeetingInfo
            {
                Id = 1,
                Location = "İstanbul",
                Date = DateTime.Now.AddDays(1),
                NumberOfPeople = UserCount

            };
             
            return View(meetingInfo);
        }

      
        
    }
}