using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class StatisticDTO
    {
        public int IdStatistic { get; set; }
        public int CountPopulation { get; set; }
        public int Year { get; set; }
        public float AverageAges { get; set; }
    }
}
