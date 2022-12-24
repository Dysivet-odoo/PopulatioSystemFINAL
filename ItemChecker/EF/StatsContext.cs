using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PopControl.DALL.Entities;

namespace PopControl.DALL.EF
{
    public class StatsContext : DbContext
    {
        public DbSet<Statistics> Stats { get; set; }
        public DbSet<Human> Human { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public StatsContext(DbContextOptions options) : base(options)
        {
        }
    }
}
