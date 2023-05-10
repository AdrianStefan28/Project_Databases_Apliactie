using MTAApp.DataAccess.Model;
using MTAApp.Logic;
namespace MTAApp.UnitTest.V
{
    [TestClass]
    public class ApartmentServiceTests
    {
        [TestMethod]
        public void CalculateWaterPay_Return_WaterPayCost()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            Apartment a = new Apartment()
            {
                Id = 1,
                ApNumber = 6,
                TenantName = "Test",
                ColdWater = 22,
                HotWater = 11,
                UserId = 1
            }; 


            ApartmentService service = new ApartmentService(null);

            //Act
            //execute the code to be tested
            var calculateWaterPay = service.CalculateWaterPay(a);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual(165, calculateWaterPay);

        }
        [TestMethod]
        public void CalculateTrashPay_Return_TrashPayCost()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            Apartment a = new Apartment()
            {
                Id = 1,
                ApNumber = 3,
                TenantName = "Test",
                NoPeople = 3,
                UserId = 1
            };

            ApartmentService service = new ApartmentService(null);

            //Act
            //execute the code to be tested
            var calculateTrashPay = service.CalculateTrashPay(a);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual(33, calculateTrashPay);

        }
        [TestMethod]
        public void GetTenantName_Return_ApartmentTenantName()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            Apartment a = new Apartment()
            {
                Id = 1,
                ApNumber = 3,
                TenantName = "Ion Ionescu",
                UserId = 1
            };

            ApartmentService service = new ApartmentService(null);

            //Act
            //execute the code to be tested
            var getTenantName = service.GetApartmentTenantName(a);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual("Ion Ionescu", getTenantName);

        }
    }
}