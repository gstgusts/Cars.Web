using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Data.Models
{
    public class CarHistory
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public Car Car { get; set; }

        public Owner Owner { get; set; }

        public int CarId { get; set; }

        public int OwnerId { get; set; }
    }
}
