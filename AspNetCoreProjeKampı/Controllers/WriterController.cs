using AspNetCoreProjeKampı.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.Controllers
{
    //[Authorize]
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        //[AllowAnonymous]
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.userMail = userMail;
            Context context = new Context();
            var writerName = context.Writers.Where(writer => writer.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        //[Authorize]
        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

         [HttpGet]
         public IActionResult WriterEditProfile()
        {
            var userMail = User.Identity.Name;
            Context context = new Context();
            var writerId = context.Writers.Where(writer => writer.WriterMail == userMail).Select(writer => writer.WriterId).FirstOrDefault();
            var writerValues = writerManager.GetById(writerId);
            return View(writerValues);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                writer.WriterStatus = true;
                writerManager.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage writerModel)
        {
            Writer writerToAdd = new Writer();
            if (writerModel.WriterImage != null)
            {
                var extension = Path.GetExtension(writerModel.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                writerModel.WriterImage.CopyTo(stream);
                writerToAdd.WriterImage = newImageName;
            }

            writerToAdd.WriterMail = writerModel.WriterMail;
            writerToAdd.WriterName = writerModel.WriterName;
            writerToAdd.WriterPassword = writerModel.WriterPassword;
            writerToAdd.WriterAbout = writerModel.WriterAbout;
            writerToAdd.WriterStatus = true;

            writerManager.Add(writerToAdd);

            return RedirectToAction("Index","Dashboard");
        }
    }
}
