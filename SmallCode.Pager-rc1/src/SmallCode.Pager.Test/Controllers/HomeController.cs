using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SmallCode.Pager.Test.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SmallCode.Pager.Test.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            PagedList<User> data = new PagedList<User>();
            //IQueryable<User> users = new IQueryable<User>();
            //for (int i = 0; i < 50; i++)
            //{
            //    users.Add(new Models.User { Id = i, UserName = "admin", Password = "12334" });
            //}
            //data = users.ToPagedList(1, 20);
            return View();
        }
    }
}
