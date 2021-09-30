using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAllWithBlogId(int id);
        void Add(Comment comment);
        //void Update(Comment comment);
        //void Delete(Comment comment);
    }
}
