using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5Garage.Vehicles
{

    public class Bus: Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(int NumberOfSeats, string registrationNumber, string color, int numberOfWheels) : base(registrationNumber, color, numberOfWheels)
        {
            this.NumberOfSeats = NumberOfSeats;
        
        
        
        
        }



    }
}
