using Exercise5Garage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Exercise5Garage
{ 
    public class Handler:IHandler 
    {
        private IGarage<IVehicle> myGarage;
        public bool IsGaragefull 
        {
            get 
            {
                if(myGarage.CountVehicles==myGarage.MaximumParkingSpots)
                return true;
                return false;
            } 
        }
        public bool IsGarageEmpty
        {

            get
            {
                if (myGarage.CountVehicles ==0)
                    return true;
                return false;
            }
        }
        public Handler(string name, int maximumParkingSpots) 
        {
            this.myGarage = new Garage<IVehicle>(name, maximumParkingSpots);
        }
        public string SeedData()
        {
            if (IsGaragefull)
                return "--GARAGE FULL ALREADY---";

            List<Vehicle> vehiclesTOSEED = new List<Vehicle>();
            vehiclesTOSEED.Add(new Boat("Diesel", "AAC211", "GEEN", 0));
            vehiclesTOSEED.Add(new Boat("Diesel", "BSW211", "YELLOW", 0));
            vehiclesTOSEED.Add(new Boat("Diesel", "UUU199", "RED", 0));
            vehiclesTOSEED.Add(new Boat("Diesel", "NNN765", "YELLOW", 0));
            vehiclesTOSEED.Add(new Car(4, "ABC123", "GREEN", 4));
            vehiclesTOSEED.Add(new Car(4, "AGF993", "RED", 4));
            vehiclesTOSEED.Add(new Car(4, "AFF003", "YELLOW", 4));
            vehiclesTOSEED.Add(new Car(4, "OPN990", "RED", 4));
            vehiclesTOSEED.Add(new Airplane(10, "ABC321", "BLUE", 20));
            vehiclesTOSEED.Add(new Airplane(10, "LLM001", "GREEN", 20));
            vehiclesTOSEED.Add(new Airplane(10, "PNU001", "RED", 20));
            vehiclesTOSEED.Add(new Motorcycle(2, "OOW444", "YELLOW", 100));
            vehiclesTOSEED.Add(new Motorcycle(2, "NBU444", "RED", 100));
            vehiclesTOSEED.Add(new Motorcycle(2, "MBQ410", "BLUE", 100));
            vehiclesTOSEED.Add(new Bus(200, "HHH876", "GREEN", 100));
            vehiclesTOSEED.Add(new Bus(200, "UUN086", "RED", 100));
            vehiclesTOSEED.Add(new Bus(200, "ABB965", "BLUE", 100));

            foreach (Vehicle vehicle in vehiclesTOSEED)
            {
                if (myGarage.CountVehicles < myGarage.MaximumParkingSpots)
                    myGarage.AddVehicle(vehicle);//lägg till i arrayen[] garage om true
                else return $"Garage is full ({myGarage.CountVehicles}/{myGarage.MaximumParkingSpots})";
            }
            return $"Garage is not full ({myGarage.CountVehicles}/{myGarage.MaximumParkingSpots})"; //Number of Vehciles in Array
        }
        public IEnumerable<IVehicle> GetAllVehiclesAtGarageEnumerator()
        {
           return myGarage.Where(I => I != null); 
        }
        public string RemoveVehicle(string regNr2) // ok! 
        { 
            if (0 < myGarage.CountVehicles)// mer vehicles än 0. dvs 1. 
            {
                var parkedVehicles = myGarage.Where(Item => Item != null).ToList(); //Tolist och ta bort alla null i arrayen!!
                var parkedVehiclesRemainder = parkedVehicles.Where(Item => Item.RegistrationNumber != regNr2); 
                var removedVehicle = parkedVehicles.FirstOrDefault(Item => Item.RegistrationNumber == regNr2);
                if (removedVehicle == null)
                    return "--Your vehicle was not found in our very long list--";
                myGarage.ClearGarageArray();// Måste Tömma Arrayen först 
                foreach (var v in parkedVehiclesRemainder) // fylla på nytt, men utan fordonet vi tog bort (Reaminder) dvs resten
                {
                   // if (myGarage.CountVehicles < myGarage.MaximumParkingSpots)
                        myGarage.AddVehicle(v);
                }
                return $"{removedVehicle.ToString()} --- was removed from garage ({myGarage.CountVehicles}/{myGarage.MaximumParkingSpots})"; //skriver ut vilken vehicle som avslutade parkering
            }else return $"Garage was already empty"; //Garaget var redan tomt 
        }
        public void Park(IVehicle vehicle) 
        {
            myGarage.AddVehicle(vehicle);
        }
        public IEnumerable<IVehicle> QuaryByColor(string color)
        {
                var listtt = myGarage.Where(I => I != null).ToList();

                var listtColor = from Vehicle in listtt
                                 where Vehicle.Color == color
                                 select Vehicle;
                return listtColor;
        }
        public IEnumerable<IVehicle> QuaryByColorWheel(IEnumerable <IVehicle> listtColor, int wheels)
        {
              //filter by color and wheels
                var listColorWheels = from Vehicle in listtColor
                                      where Vehicle.NumberOfWheels >= wheels
                                      select Vehicle;
               return listColorWheels;
          
        }
        public IEnumerable<IVehicle> QuaryByColorWheelType(IEnumerable <IVehicle> listColorWheels, int typeParked)
        { 
                //--- Filter by color and wheels and now also type (car, boat etc)
                switch (typeParked)
                {
                    case 1:
                    return listColorWheels.OfType<Car>();
                    case 2:
                    return listColorWheels.OfType<Boat>();
                    case 3:
                    return listColorWheels.OfType<Bus>();
                    case 4:
                    return listColorWheels.OfType<Motorcycle>();
                    case 5:
                    return listColorWheels.OfType<Airplane>();
                }
            return null!;   
        }
        public string Stats()
        {
            var listOfstats = myGarage.Where(I => I != null).ToList();

            //Type
            var numberOfCars = listOfstats.Where(Item => Item is Car).Count();
            var numberOfBoats = listOfstats.Where(Item => Item is Boat).Count();
            var numberOfBuses = listOfstats.Where(Item => Item is Bus).Count();
            var numberOfMotorcycles = listOfstats.Where(Item => Item is Motorcycle).Count();
            var numberOfAirplanes = listOfstats.Where(Item => Item is Airplane).Count();
        
            string statsType = $" Cars: {numberOfCars} \n Boats:{numberOfBoats} \n Busses: {numberOfBuses} \n Motorcycles: {numberOfMotorcycles} \n Airplanes: {numberOfAirplanes} \n";
            //Colors
            var numberOfBLUE = listOfstats.Where(Item => Item.Color=="BLUE").Count();
            var numberOfGREEN = listOfstats.Where(Item => Item.Color == "GREEN").Count();
            var numberOfRED = listOfstats.Where(Item => Item.Color == "RED").Count();
            var numberOfYELLOW = listOfstats.Where(Item => Item.Color == "YELLOW").Count();
          
            string statsColor = $" BLUE: {numberOfBLUE} \n GREEN:{numberOfGREEN} \n RED: {numberOfRED} \n YELLOW: {numberOfYELLOW} \n";
            //Wheels
            var nrWheelsTwo = listOfstats.Where(Item => Item.NumberOfWheels == 2).Count();
            var nrWheelsfour = listOfstats.Where(Item => Item.NumberOfWheels == 4).Count();
            var nrWheelsFour = listOfstats.Where(Item => Item.NumberOfWheels >= 4).Count();
            var nrWheelsTen = listOfstats.Where(Item => Item.NumberOfWheels >= 10).Count();
          
            string statsWheels = $" Two wheels: {nrWheelsTwo} \n Four wheels :{nrWheelsfour} \n Four and more: {nrWheelsFour} \n Ten and more: {nrWheelsTen} \n";
            string parkingStatus =$"\n Parking status: ({myGarage.CountVehicles}/{myGarage.MaximumParkingSpots})";

            return string.Concat("----STATISTICS---- \n",statsType,statsColor, statsWheels,parkingStatus); //CONCAT ALLT! 
        }
    }
}
    