using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopControl.DALL.UnitOfWork;
using PopControl.DALL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using PopControl.DALL.Repositories.Interfaces;

namespace PopControl.DALL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private StatsContext db;
        private StatisticRepository statsRepository;
        private HumanRepository humanRepository;
        private LocalityRepository localityRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new StatsContext(options);
        }

        public IStatisticRepository Statistics
        {
            get
            {
                if (statsRepository == null)
                    statsRepository = new StatisticRepository(db);
                return statsRepository;
            }
        }

        public IHumanRepository Humans
        {
            get
            {
                if (humanRepository == null)
                    humanRepository = new HumanRepository(db);
                return humanRepository;
            }
        }

        public ILocalityRepository Localitys
        {
            get
            {
                if (localityRepository == null)
                    localityRepository = new LocalityRepository(db);
                return localityRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose() 
        { 
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
