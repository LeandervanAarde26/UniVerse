using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UniVerse.Models
{
    public class LecturerFees
    {
        public int id { get; set; }

        public string lecturer { get; set; }

        public decimal totalHoursWorked { get; set; }

        public decimal monthlyIncome { get; set; }
    }
}
