namespace Exercise5Garage.Vehicles
{
    public interface IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        public string ToString();
        
        //public IEnumerator<Vehicle> GetEnumerator();
      
    }
}