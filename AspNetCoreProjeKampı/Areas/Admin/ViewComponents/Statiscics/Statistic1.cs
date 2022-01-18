using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace AspNetCoreProjeKampı.Areas.Admin.ViewComponents.Statiscics
{
    public class Statistic1 : ViewComponent
    {
        IBlogService blogService = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.countOfTotalBlog = blogService.GetAll().Count;
            ViewBag.countOfNewMessage = context.Contacts.Count();
            ViewBag.countOfTotalComment = context.Comments.Count();

            string apiKey = "e239e56610618b852bca2cfd39c52014";
            string apiUrl = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + apiKey;
            XDocument document = XDocument.Load(apiUrl);
            ViewBag.temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
           
            return View();
        }
    }
}
