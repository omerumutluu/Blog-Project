using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.categoryCount = context.Categories.Count();
            ViewBag.blogCountByWriter = context.Blogs.Where(blog => blog.WriterID == 1).Count();
            ViewBag.blogCount = context.Blogs.Count();
            return View();
        }
    }
}
