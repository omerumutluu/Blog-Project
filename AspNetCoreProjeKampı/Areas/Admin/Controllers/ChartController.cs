using AspNetCoreProjeKampı.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> categoryList = new List<CategoryClass>();

            categoryList.Add(
                new CategoryClass
                {
                    categoryname = "Teknoloji",
                    categorycount = 10
                });
            categoryList.Add(
                new CategoryClass
                {
                    categoryname = "Yazılım",
                    categorycount = 14
                });
            categoryList.Add(
                new CategoryClass
                {
                    categoryname = "Spor",
                    categorycount = 14
                });

            return Json(new { jsonlist = categoryList });
        }
    }
}
