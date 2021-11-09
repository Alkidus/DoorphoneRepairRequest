using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Repository;

namespace WebApp.Models
{
    public class DomofonKeyRepository : IRepository<DomofonKey>
    {
        private SubscriberContext db;
        public DomofonKeyRepository(SubscriberContext context)
        {
            db = context;
        }
        public void Create(DomofonKey item)
        {
            db.DomofonKeys.Add(item);
        }

        public void Delete(int id)
        {
            DomofonKey domofonKey = db.DomofonKeys.Find(id);
            if (domofonKey != null)
                db.DomofonKeys.Remove(domofonKey);
        }

        public void Edit(DomofonKey item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<DomofonKey> GetAllList()
        {
            return db.DomofonKeys;
        }

        public DomofonKey GetByID(int? id)
        {
            return db.DomofonKeys.Find(id.Value);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
