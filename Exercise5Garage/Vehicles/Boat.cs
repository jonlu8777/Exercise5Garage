using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5Garage.Vehicles
{
    public class Boat : Vehicle
    {
        public string FuelType { get; set; }
        public Boat(string fuelType, string registrationNumber, string color, int numberOfWheels):base(registrationNumber,color,numberOfWheels)
        {
            this.FuelType = fuelType;
        }
     





    }
}
