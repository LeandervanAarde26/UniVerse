using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UniVerse.Models
{
    public class Fees
    {
        public int id { get; set; }

        public string lecturer { get; set; }

        public int? totalHoursWorked { get; set; }

        public int? monthlyIncome { get; set; }
    }
}
