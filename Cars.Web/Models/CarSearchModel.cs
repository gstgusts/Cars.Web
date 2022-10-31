using System.ComponentModel;

namespace Cars.Web.Models
{
    public class CarSearchModel
    {
        [DisplayName("VIN")]
        public string VinNumber { get; set; }

        [DisplayName("Registration plate number")]
        public string RegistrationPlate { get; set; }
    }
}
