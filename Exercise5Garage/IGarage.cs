using Exercise5Garage.Vehicles;

namespace Exercise5Garage
{
    public interface IGarage<T> : IEnumerable<T> where T: IVehicle
    {
        public int CountVehicles { get; set; }
        public int MaximumParkingSpots { get; }
        public string Name { get; set; }
     
        public void AddVehicle(T vehicle); //Park a new vechile.
    
        public void ClearGarageArray();
     
        public IEnumerable<T> GetIEnumerable();
    }
}