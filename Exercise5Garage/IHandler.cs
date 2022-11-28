using Exercise5Garage.Vehicles;

namespace Exercise5Garage
{
    internal interface IHandler 
    {
        

        bool IsGaragefull { get; }
        public bool IsGarageEmpty
        {

            get;
           
        }
        internal string SeedData();
        internal IEnumerable<IVehicle> GetAllVehiclesAtGarageEnumerator();
        internal string RemoveVehicle(string regNr2); 
        internal void Park(IVehicle bus);
        public IEnumerable<IVehicle> QuaryByColor(string color);
        public IEnumerable<IVehicle> QuaryByColorWheel(IEnumerable<IVehicle> listtColorWheel, int type);

        public IEnumerable<IVehicle> QuaryByColorWheelType(IEnumerable<IVehicle> listtColorWheelType, int type);
        internal string Stats();
        
  
    }
}