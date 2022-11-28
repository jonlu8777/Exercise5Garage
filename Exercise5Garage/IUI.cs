using Exercise5Garage.Vehicles;

namespace Exercise5Garage
{
    public interface IUI
    {
        public void Clear();
        public void SettingsUI(string name);
        public Bus CreateBus();
        public Boat CreateBoat();
        public Motorcycle CreateMotorcycle();
        public Airplane CreateAirplane();
        public Car CreateCar();
        public int AskForVehicleType();
        public void PrintMainMeny();
       
        public string GetInput();

        public void Print(string message);

        public string AskForString(string promt);

        public int AskForInt(string promt);


        public void PrintAll(IEnumerable<IVehicle> vehicleSeed);

        public string AskForColor();

        public string AskForRegistrationNr();

    }
}