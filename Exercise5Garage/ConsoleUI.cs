using Exercise5Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise5Garage
{
    public class ConsoleUI : IUI
    {
        public ConsoleUI()
        {

        }

        public void SettingsUI(string name)
        {
            Console.CursorVisible = false;
            Console.Title = name;
        }
        public void Clear()
        { 
        Console.Clear();
        }
        public string GetInput()
        {
            return Console.ReadLine()!;
        }
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
        public string AskForString(string promt)
        {

            Print($"{promt}:");
            do
            {
                string answer = GetInput();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    Print("Enter a valid value!");
                }
                else
                {
                    return answer;
                }
            } while (true);
        }
        public int AskForInt(string promt)
        {
            do
            {
                if (int.TryParse(AskForString(promt), out int answer))
                    return answer;
                Print("Not an Int");
            }
            while (true);
        }

        public void PrintMainMeny()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        Main Menu");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Seed data");
            Console.WriteLine("2. Park a Vehicle to garage");
            Console.WriteLine("3. Unpark Vehicle from garage");
            Console.WriteLine("4. Print all Vehicle at garage");
            Console.WriteLine("5. Quary by color -> wheels -> type");
            Console.WriteLine("6. Statistics");
            Console.WriteLine("7. Exit application");
            Console.WriteLine("-------------------------------");
        }
        public void PrintAll(IEnumerable<IVehicle> vehicleSeed)
        {
            foreach (var v in vehicleSeed)
                Console.WriteLine(v);
        }
        public string AskForColor()
        {
            Dictionary<int, string> dic_colors = new Dictionary<int, string>(){
                                  {1, "BLUE"},
                                  {2, "GREEN"},
                                  {3, "RED"},
                                  {4, "YELLOW"} };
            Print($"Pick a color:");
            Print($"{dic_colors.Keys.ElementAt(0)}. {dic_colors.Values.ElementAt(0)}");
            Print($"{dic_colors.Keys.ElementAt(1)}. {dic_colors.Values.ElementAt(1)}");
            Print($"{dic_colors.Keys.ElementAt(2)}. {dic_colors.Values.ElementAt(2)}");
            Print($"{dic_colors.Keys.ElementAt(3)}. {dic_colors.Values.ElementAt(3)}");

            do
            {

                if (int.TryParse(GetInput(), out int res))
                    if (res <= 4 && res >= 1)
                    {

                        return dic_colors.Values.ElementAt(res - 1).ToString();
                    }
                    else
                    {

                        Print("Enter a valid value!");


                    }
            } while (true);
        }

        public string AskForRegistrationNr()
        {

            do
            {
                int CountTrue = 0;
                string mixedinput = AskForString("Enter registraion number as ABC123");



                if (mixedinput.Length == 6)
                    for (int i = 0; i < 3; i++)
                    {
                        if (Char.IsLetter(mixedinput[i]))
                            if (Char.IsDigit(mixedinput[i + 3]))
                                CountTrue++;
                    }
                if (CountTrue == 3)
                {

                    return mixedinput.ToUpper();
                }
                else
                {

                    Print("Enter a valid value (ABC123)!");


                }
            } while (true);

        }
        public int AskForVehicleType()
        {
            int nrPicked;
            do
            {
               
                Print("1. Car");
                Print("2. Boat");
                Print("3. Bus");
                Print("4. Motorcycle");
                Print("5. Airplane");
                nrPicked = AskForInt($"Pick what vehicle (int) you want to choose");
            } while (nrPicked < 0 || nrPicked > 5);
            return nrPicked;

        }

        public Bus CreateBus()
        {
            Print("--Add Vehicle--");
            Print("--A Bus--");
            var numberOfSeats = AskForInt("Enter number of seats (int)");
            var regNr = AskForRegistrationNr();
            var color = AskForColor();
            var numberOfWheels = AskForInt("enter number of wheels");

            Bus bus = new Bus(numberOfSeats, regNr, color, numberOfWheels);
            return bus;
        }

        public Boat CreateBoat()
        { 
        Print("--Add Vehicle--");
        Print("--A Boat--");
        var fuelType = AskForString("Enter fueltype (string)");
        var regNr = AskForRegistrationNr();
        var color = AskForColor();
        var numberOfWheels = AskForInt("enter number of wheels");
        var vehicle = new Boat(fuelType, regNr, color, numberOfWheels);
         return vehicle;
            }
        public Airplane CreateAirplane()
        {
            Print("--Add Vehicle--");
            Print("--A Airplane--");
            var wingspan = AskForInt("Enter wingspan (int)");
            var regNr = AskForRegistrationNr();
            var color = AskForColor();
            var numberOfWheels = AskForInt("enter number of wheels");
            return new Airplane(wingspan, regNr, color, numberOfWheels);
            
        }
        public Car CreateCar()
        {
            Print("--Add Vehicle--");
            Print("--A Car--");
            var numberOfcylenders = AskForInt("Enter size of engine (int)");
            var regNr = AskForRegistrationNr();
            var color = AskForColor();
            var numberOfWheels = AskForInt("enter number of wheels");
            return  new Car(numberOfcylenders, regNr, color, numberOfWheels);
        }
        public Motorcycle CreateMotorcycle()
        {
            Print("--Add Vehicle--");
            Print("--A motorcycle--");
            var sizeOfEngine = AskForInt("Enter size of engine (int)");
            var regNr = AskForRegistrationNr();
            var color = AskForColor();
            var numberOfWheels = AskForInt("enter number of wheels");
            return new Motorcycle(sizeOfEngine, regNr, color, numberOfWheels);

        }

      
    }
}

    
    

