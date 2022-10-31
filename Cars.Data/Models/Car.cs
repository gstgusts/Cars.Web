using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("VIN")]
        public string VinNumber { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Registration plate number")]
        public string RegistrationPlate { get; set; }

        public Owner? Owner { get; set; }

        public int? OwnerId { get; set; }

        public CarTypeEnum? Type { get; set; }

        public int? Year { get; set; }

        [DisplayName("Engine Type")]
        public CarEngineTypeEnum? EngineType { get; set; }
    }
}
