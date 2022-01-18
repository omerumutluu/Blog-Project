using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.Controllers
{
    public class NotificationController : Controller
    {
        INotificationService _notificationService = new NotificationManager(new EfNotificationRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult GetAllNotification()
        {
            var values = _notificationService.GetAll();
            return View(values);
        }
    }
}
