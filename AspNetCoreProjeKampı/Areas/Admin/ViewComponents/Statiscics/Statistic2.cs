using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreProjeKampı.Areas.Admin.ViewComponents.Statiscics
{
    public class Statistic2 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.lastBlogName = context.Blogs.Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            return View();
        }
    }
}
