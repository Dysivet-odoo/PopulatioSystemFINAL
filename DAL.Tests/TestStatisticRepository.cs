using System;
using System.Collections.Generic;
using System.Text;
using PopControl.DALL.EF;
using PopControl.DALL.Entities;
using PopControl.DALL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    class TestStatisticRepository : BaseRepository<Statistics>
    {
        public TestStatisticRepository(DbContext context) : base(context)
        {
        }
    }
}
