using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public enum Sex
    {
        Male,
        Female
    }
    public class HumanDTO
    {
        public int IdHuman { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
    }
}
