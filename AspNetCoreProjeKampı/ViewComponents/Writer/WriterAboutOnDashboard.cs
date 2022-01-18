using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            Context context = new Context();
            var writerId = context.Writers.Where(writer => writer.WriterMail == userMail).Select(writer => writer.WriterId).FirstOrDefault();
            var values = writerManager.GetById(writerId);
            return View(values);
        }
    }
}
