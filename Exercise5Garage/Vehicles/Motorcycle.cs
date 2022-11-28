using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5Garage.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int SizeOfEngine { get; set; }

        public Motorcycle(int sizeOfEngine, string registrationNumber, string color, int numberOfWheels) : base(registrationNumber, color, numberOfWheels)
        {

        }

    }
}
