using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string VinNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string RegistrationPlate { get; set; }

        public Owner? Owner { get; set; }
    }
}
