using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.Areas.Admin.ViewComponents.Statiscics
{
    public class Statistic3 : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
