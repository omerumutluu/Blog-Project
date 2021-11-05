using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetLastThreeBlog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }

        public List<Blog> GetAllWithCategory()
        {
            return _blogDal.GetAllWithCategory();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetAllWithFilter(b => b.BlogId == id);
        }

        public List<Blog> GetAllByWriter(int id)
        {
            return _blogDal.GetAllWithFilter(b => b.WriterID == id);
        }

        public List<Blog> GetAllWithCategoryByWriter(int id)
        {
            return _blogDal.GetAllWithCategoryByWriter(id);
        }
    }
}
