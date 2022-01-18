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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public void Add(Message2 entity)
        {
            _message2Dal.Add(entity);
        }

        public void Delete(Message2 entity)
        {
            _message2Dal.Delete(entity);
        }

        public List<Message2> GetAll()
        {
            return _message2Dal.GetAll();
        }

        public Message2 GetById(int id)
        {
            return _message2Dal.GetById(id);
        }

        public List<Message2> GetInboxByWriter(int writerId)
        {
            return _message2Dal.GetAllWithWriterDetailsByWriter(writerId);
        }

        public void Update(Message2 entity)
        {
            _message2Dal.Update(entity);
        }
    }
}
