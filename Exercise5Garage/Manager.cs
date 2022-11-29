using Exercise5Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5Garage
{
    internal class Manager
    {
      internal void Run()
      {
            
            IUI ui = new ConsoleUI();
            ui.SettingsUI("---Create a dream garage--");
            ui.Print("---Welcome---");
            ui.Print("Create a new Garage");
            var name = ui.AskForString("Enter a garage name");
            ui.SettingsUI(name);
            var maximumParkingSpots = ui.AskForInt("Enter the size of your garage");
            IHandler handler = new Handler(name, maximumParkingSpots); //Ett nytt Garage skapas i Handlers construktor
            ui.Print($"---Success--- \n{name} has been created \n{maximumParkingSpots} parking spots available \n-------------");
            do
            {
                ui.GetInput(); //avvakta användaren varje do loop
                ui.Clear();
                ui.PrintMainMeny(); //Print MENU
                string s = ui.GetInput();
                switch (s.Trim())
                {
                    case "1":
                        //. SEED DATA"
                        ui.Clear();
                        ui.Print("-----Seed vehicles to garage----");
                        ui.Print($"Number of vehicles seeded:{handler.SeedData()}");
                        break;
                    case "2"://add new vehicle to garage             
                        ui.Clear();
                        if (!handler.IsGaragefull)
                        {
                           int nrPicked= ui.AskForVehicleType(); // Fordon skapas i consoleUI
                            if (nrPicked == 1)                   //utefter vilken typ man valt, 
                               handler.Park(ui.CreateCar());     //Jag har inte skickat någon instans av UI
                            if (nrPicked == 2)                   // Till Handlern istället skickar handlern strängar tillbaka till managerklassen
                               handler.Park(ui.CreateBoat());
                            if (nrPicked == 3)
                               handler.Park(ui.CreateBus());
                            if (nrPicked == 4)
                               handler.Park(ui.CreateMotorcycle());
                            if (nrPicked == 5)
                               handler.Park(ui.CreateAirplane());
                              ui.Print("--Vehicle parked--");
                        }
                          else ui.Print($"---{name} is full---"); 
                    break;
                    case "3":
                        ui.Clear();
                        //Unpark vehicle       ---OK ! 
                        if (!handler.IsGarageEmpty)
                        {
                            ui.Print("--Unpark Vehicle--");
                            ui.PrintAll(handler.GetAllVehiclesAtGarageEnumerator()); //hämtar hela listan, lämnar till ui.PrintAll
                            var regNr = ui.AskForRegistrationNr();
                            ui.Clear();
                            ui.Print(handler.RemoveVehicle(regNr));
                        }
                        else ui.Print($"---{name} was empty---");
                        break;
                    case "4":
                        ui.Clear();
                        //Print ALL PARKED VEHCILES AT GARAGE 
                        if (!handler.IsGarageEmpty)
                        {
                            ui.Print("--Print All Vehicles--");
                            ui.PrintAll(handler.GetAllVehiclesAtGarageEnumerator()); //hämtar hela listan, lämnar till ui.PrintAll
                        }
                        else ui.Print($"---{name} was empty---");
                        break;
                    case "5": //Quary på färg -> hjul -> typ
                        ui.Clear();
                        if (!handler.IsGarageEmpty)
                        {
                            ui.Print("View by color");
                            var color = ui.AskForColor();
                            ui.Clear();
                            var listtColor = handler.QuaryByColor(color);
                            ui.PrintAll(listtColor);
                            var wheels = ui.AskForInt("--View by wheels (vehicles have at minimum)-- ");
                            ui.Clear();
                            var listColorWheels = handler.QuaryByColorWheel(listtColor, wheels);
                            ui.PrintAll(listColorWheels);
                            var type = ui.AskForVehicleType();
                            ui.Clear();
                            var listColorWheelsType = handler.QuaryByColorWheelType(listColorWheels, type);
                            ui.PrintAll(listColorWheelsType);
                            ui.Print("---Finished---");
                        }
                        else ui.Print($"---{name} was empty---");
                        break;
                    case "6": //Statestik 
                        ui.Clear();
                        if (!handler.IsGarageEmpty)
                        {
                            ui.Print(handler.Stats());
                        }
                        else ui.Print($"---{name} was empty---");
                        break;
                    case "7":
                        // Exit application
                        ui.Print("--Goodbye---");
                        Environment.Exit(0); 
                        break;
                }
            } while(true);
        }
    }
}
