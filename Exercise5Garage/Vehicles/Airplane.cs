using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5Garage.Vehicles
{
    public class Airplane:Vehicle
    {
        public int Wingspan { get; set; }
        public Airplane(int wingspan, string registrationNumber, string color, int numberOfWheels) : base(registrationNumber, color, numberOfWheels)
        {
            this.Wingspan = wingspan;
            
        }
    }
}
