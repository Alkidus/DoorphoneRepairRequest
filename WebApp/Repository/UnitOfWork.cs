using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repository
{
    public class UnitOfWork
    {
        private SubscriberContext context = new SubscriberContext();
        private GenericRepository<Adress> adressRepository;
        private GenericRepository<DomofonKey> domofonKeyRepository;
        private GenericRepository<DomofonSystem> domofonSystemRepository;

        public GenericRepository<Adress> AdressRepository
        {
            get
            {

                if (this.adressRepository == null)
                {
                    this.adressRepository = new GenericRepository<Adress>(context);
                }
                return adressRepository;
            }
        }

        public GenericRepository<DomofonKey> DomofonKeyRepository
        {
            get
            {

                if (this.domofonKeyRepository == null)
                {
                    this.domofonKeyRepository = new GenericRepository<DomofonKey>(context);
                }
                return domofonKeyRepository;
            }
        }

        public GenericRepository<DomofonSystem> DomofonSystemRepository
        {
            get
            {

                if (this.domofonSystemRepository == null)
                {
                    this.domofonSystemRepository = new GenericRepository<DomofonSystem>(context);
                }
                return domofonSystemRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
