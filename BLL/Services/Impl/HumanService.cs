using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services.Interfaces;
using PopControl.DALL.UnitOfWork;
using CLL.Security;
using CLL.Security.Identity;
using PopControl.DALL.Entities;
using AutoMapper;

namespace BLL.Services.Impl
{
    public class HumanService
        : IHumanService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
        public HumanService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }
        public IEnumerable<HumanDTO> GetHumans(int page)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Sociologist)
                && userType != typeof(Analytik))
            {
                throw new MethodAccessException();
            }
            var humanId = user.UserId;
            var streetsEntities =
                _database
                    .Humans
                    .Find(z => z.IdHuman == humanId, page, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Human, HumanDTO>()
                    ).CreateMapper();
            var humanDto =
                mapper
                    .Map<IEnumerable<Human>, List<HumanDTO>>(
                        streetsEntities);
            return humanDto;
        }
    }
}
