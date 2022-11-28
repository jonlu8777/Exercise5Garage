using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5Garage.Vehicles
{
    public class Car:Vehicle
    {
        public int NumberOfcylenders { get; set; }

        public Car(int numberOfcylenders, string registrationNumber, string color, int numberOfWheels) : base(registrationNumber, color, numberOfWheels)
        {

        }

    }
}
