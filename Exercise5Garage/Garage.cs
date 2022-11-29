using Exercise5Garage.Vehicles;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace Exercise5Garage
{
    public class Garage<T> : IGarage<T> where T : IVehicle
    {
        private T[] vehicles;
        private readonly int maximumParkingSpots;
        public int CountVehicles { get; set; }
        public int MaximumParkingSpots { get { return maximumParkingSpots; } }
        public string Name { get; set; }
        public Garage(string name, int maximumParkingSpots)
        {
            CountVehicles = 0;
            this.maximumParkingSpots = maximumParkingSpots;
            this.vehicles = new T[maximumParkingSpots];
            this.Name = name;
        }
        public void AddVehicle(T vehicle) //Park a new vechile.
        {
            vehicles[CountVehicles++] = vehicle;
        }
        public void ClearGarageArray()
        {
            Array.Clear(vehicles, 0, CountVehicles);
            CountVehicles = 0;
        }
        private IEnumerable<T> GetIEnumerable()  
        {
            foreach (var v in vehicles)
            {
                yield return v;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return GetIEnumerable().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
