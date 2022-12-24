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
    public class StatisticRepository
        : BaseRepository<Statistics>, IStatisticRepository
    {
        internal StatisticRepository(StatsContext context) : base(context)
        {
        }
    }
}
