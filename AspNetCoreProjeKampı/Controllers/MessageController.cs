using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        IMessage2Service _message2Service = new Message2Manager(new EfMessage2Repository());
        public IActionResult Inbox()
        {
            int id = 2;
            var values = _message2Service.GetInboxByWriter(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = _message2Service.GetById(id);
            return View(value);
        }
    }
}
