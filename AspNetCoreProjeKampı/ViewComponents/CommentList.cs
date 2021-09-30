using AspNetCoreProjeKampı.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment{Id =1, Username ="Ömer"},
                new UserComment{Id = 2, Username = "Mesut"},
                new UserComment{Id = 3, Username = "Merve"}
            };
            return View(commentValues);
        }
    }
}
