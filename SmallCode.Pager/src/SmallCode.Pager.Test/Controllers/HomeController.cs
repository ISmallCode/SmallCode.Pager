using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmallCode.Pager.Test.Models;
using SmallCode.Pager;

namespace SmallCode.Pager.Test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int page = 1)
        {
            PagedList<User> data = new PagedList<User>();
            List<User> users = new List<Models.User>();

            for (int i = 0; i < 50; i++)
            {
                users.Add(new Models.User { Id = i, UserName = "admin", Password = "12334" });
            }

            data = users.AsQueryable().ToPagedList(page, 20);
            return View(data);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
