using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise5Garage.Vehicles
{
    public abstract class Vehicle: IVehicle
    {
       
        public string RegistrationNumber { get; set; }
        public string  Color { get; set; }
        public int NumberOfWheels { get; set; }

        public Vehicle(string registrationNumber, string color, int numberOfWheels)
            {
            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                throw new ArgumentException($"'{nameof(registrationNumber)}' cannot be null or whitespace.", nameof(registrationNumber));
            }
            this.RegistrationNumber = registrationNumber;
            this.Color = color;
            this.NumberOfWheels = numberOfWheels;
            

            }

        public override string ToString()
        {
            return $"Type: {GetType().Name},Reg. number: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}";

        }

      

        //public IEnumerator<Vehicle> GetEnumerator()
        //{

        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
