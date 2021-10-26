using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Repository;

namespace WebApp.Models
{
    public class AdressRepository : IRepository<Adress>
    {
        private SubscriberContext db;
        public AdressRepository(SubscriberContext context)
        {
            db = context;
        }
        public void Create(Adress item)
        {
            db.Adresses.Add(item);
        }

        public void Delete(int id)
        {

            Adress adress = db.Adresses.Find(id);
            if (adress != null)
                db.Adresses.Remove(adress);
        }

        public void Edit(Adress item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Adress GetByID(int id)
        {
            return db.Adresses.Find(id);
        }

        public IEnumerable<Adress> GetAllList()
        {
            return db.Adresses;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<DomofonKey> GetAllDomofonKeys()
        {
            return db.DomofonKeys.ToList();
        }
        public IEnumerable<DomofonSystem> GetAllDomofonSystems()
        {
            return db.DomofonSystems.ToList();
        }
        public IEnumerable<Adress> GetAllAdressToIndex()
        {
            return db.Adresses.Include(domofonkey =>
            domofonkey.DomofonKey).Include(systemtype =>
            systemtype.DomofonSystem).ToList();
        }

    }
}
