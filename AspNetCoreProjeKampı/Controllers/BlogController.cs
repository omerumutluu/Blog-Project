using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context context = new Context();

        public IActionResult Index()
        {
            var values = blogManager.GetAllWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var userMail = User.Identity.Name;
            var userId = context.Writers.Where(writer => writer.WriterMail == userMail).Select(writer => writer.WriterId).FirstOrDefault();
            var values = blogManager.GetAllWithCategoryByWriter(userId);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerId = context.Writers.Where(writer => writer.WriterMail == userMail).Select(writer => writer.WriterId).FirstOrDefault();

            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerId;
                blog.CategoryID = 3;
                blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult BlogDelete(int id)
        {
            var blogValue = blogManager.GetById(id);
            blogManager.Delete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var blogValue = blogManager.GetById(id);
            List<SelectListItem> categoryValues = (
                from x in categoryManager.GetAll()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
            ViewBag.categoryValues = categoryValues;
            ViewBag.blogId = id;
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {
            //Blog updatedBlog =  blogManager.GetById(blog.BlogId);
            //updatedBlog.BlogTitle = blog.BlogTitle;
            //updatedBlog.BlogThumbnailImage = blog.BlogThumbnailImage;
            //updatedBlog.CategoryID = blog.CategoryID;
            //updatedBlog.BlogImage = blog.BlogImage;
            //updatedBlog.BlogContent = blog.BlogContent;
            var tempBlog = blogManager.GetById(blog.BlogId);
            blog.BlogCreateDate = tempBlog.BlogCreateDate;
            blog.WriterID = tempBlog.WriterID;
            blog.BlogStatus = true;
            blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
