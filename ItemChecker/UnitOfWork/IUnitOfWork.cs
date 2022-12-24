using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopControl.DALL.Repositories.Interfaces;

namespace PopControl.DALL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStatisticRepository Statistics { get; }
        IHumanRepository Humans { get; }
        ILocalityRepository Localitys { get; }
        void Save();
    }
}
