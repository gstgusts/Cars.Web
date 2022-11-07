using Cars.Data.Models;
using System.ComponentModel;

namespace Cars.Web.Models
{
    public class CarSearchModel
    {
        [DisplayName("VIN")]
        public string VinNumber { get; set; }

        [DisplayName("Registration plate number")]
        public string RegistrationPlate { get; set; }

        public CarTypeEnum? Type { get; set; }

        public Owner? Owner { get; set; }

        public int? OwnerId { get; set; }

        public CarEngineTypeEnum? EngineType { get; set; }
    }
}
