using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Repository;

namespace WebApp.Models
{
    public class DomofonSystemRepository : IRepository<DomofonSystem>
    {
        private SubscriberContext db;
        public DomofonSystemRepository(SubscriberContext context)
        {
            db = context;
        }
        public void Create(DomofonSystem item)
        {
            db.DomofonSystems.Add(item);
        }

        public void Delete(int id)
        {
            DomofonSystem domofon = db.DomofonSystems.Find(id);
            if (domofon != null)
                db.DomofonSystems.Remove(domofon);
        }

        public void Edit(DomofonSystem item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<DomofonSystem> GetAllList()
        {
            return db.DomofonSystems;
        }

        public DomofonSystem GetByID(int id)
        {
            return db.DomofonSystems.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
