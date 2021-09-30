using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var values = _categoryManager.GetAll();
            return View(values);
        }
    }
}
