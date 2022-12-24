using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopControl.DALL.Entities;
using PopControl.DALL.Repositories.Interfaces;
using PopControl.DALL.EF;

namespace PopControl.DALL.Repositories.Impl
{
    public class LocalityRepository
        : BaseRepository<Locality>, ILocalityRepository
    {
        internal LocalityRepository(StatsContext context) : base(context)
        { 
        }

    }
}
