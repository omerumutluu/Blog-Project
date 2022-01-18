using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreProjeKampı.Areas.Admin.ViewComponents.Statiscics
{
    public class Statistic4 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = context.Admins.Where(x => x.AdminId == 1).Select(x => x.Name).FirstOrDefault();
            ViewBag.adminImageUrl = context.Admins.Where(x => x.AdminId == 1).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.adminShortDescription = context.Admins.Where(x => x.AdminId == 1).Select(x => x.ShortDescription).FirstOrDefault();

            return View();
        }
    }
}
