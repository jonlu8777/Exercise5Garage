using System.Security.Principal;
using Exercise5Garage;
using Exercise5Garage.Vehicles;

namespace TestGarageClass
{
    public class GarageTests
    {
        [Fact]
        public void AddVehicleToVehicleArray()
        {
            // Arrange
   
            IGarage<IVehicle> garage = new Garage<IVehicle>("Test_Garage", 10);
            IVehicle vehicle = new Car(1, "ABB777", "RED", 4); 
            var expected = 1; //
            // Act
            garage.AddVehicle(vehicle);
            var actual = garage.CountVehicles;
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ClearGarageArray()
        {
            // Arrange
   
            IGarage<IVehicle> garage = new Garage<IVehicle>("Test_Garage", 10);
            IVehicle vehicle = new Car(1, "ABB777", "RED", 4); 
            garage.AddVehicle(vehicle);
            var expected = 0; //
            // Act
            garage.ClearGarageArray();
            var actual = garage.CountVehicles;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckSequenceEqualInArray()
        {
            // Arrange
            IGarage<IVehicle> garage = new Garage<IVehicle>("Test_Garage", 3);
            IVehicle vehicle1 = new Car(1, "ABB111", "RED", 4); 
            IVehicle vehicle2 = new Car(1, "BBB222", "RED", 4); 
            IVehicle vehicle3 = new Car(1, "CCC333", "RED", 4); 
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            IEnumerable<IVehicle> expected = new IVehicle[] { vehicle1, vehicle2, vehicle3 };
            // Act
            var actual = garage.Where(Item=>Item is IVehicle);
            // Assert
            Assert.True(expected.SequenceEqual(actual));
        }
        //[Fact]
        //public void CheckIfThrownEnumeratorNotImplementedException()
        //{
        //    // Arrange
        //    IGarage<IVehicle> garage = new Garage<IVehicle>("Test_Garage", 3);
        //    IVehicle vehicle1 = new Car(1, "ABB111", "RED", 4);
        //    IVehicle vehicle2 = new Car(1, "BBB222", "RED", 4);
        //    IVehicle vehicle3 = new Car(1, "CCC333", "RED", 4);
        //    garage.AddVehicle(vehicle1);
        //    garage.AddVehicle(vehicle2);
        //    garage.AddVehicle(vehicle3);
           
        //    // Act
        //    // Assert
        //    Assert.Throws<NotImplementedException>(() => garage.GetEnumerator()) ;
        //}
    }
}