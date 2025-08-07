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
    public class MeetingController : Controller
    {


        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(UserInfo model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
                 
            }



            Repository.AddUser(model);


            return View("Thanks", model);
        }


        public IActionResult List()
        {
            return View(Repository.Users);
        }


        public IActionResult Details(int id)
        {
            var model = Repository.GetUserById(id);

            return View("Details", model);
        }
    }
}