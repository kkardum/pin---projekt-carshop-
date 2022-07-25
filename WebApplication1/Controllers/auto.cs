using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{
    public class auti
    {
        public int Id { get; set; }
        public string marka { get; set; }
        public string model { get; set; }

        [DataType(DataType.Date)]
        public DateTime god_proizvodnje { get; set; }
    }
}
