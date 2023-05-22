using MTAApp.DataAccess.Model;
using MTAApp.Logic;
using Moq;
using MTAApp.DataAccess.Abstractions;

namespace MTAApp.UnitTest.V
{
    [TestClass]
    public class ApartmentServiceTests
    {

        private Mock<IApartmentRepository> apartmentRepositoryMock = new Mock<IApartmentRepository>();

        [TestInitialize]
        public void InitializeTests()
        {
            Apartment existingProduct = new Apartment
            {
                Id = 1,
                ApNumber = 3,
                TenantName = "Testx",
                ColdWater = 52,
                HotWater = 66,
                UserId = 1
            };
            Apartment existingProduct2 = new Apartment
            {
                Id = 2,
                ApNumber = 6,
                TenantName = "Test",
                ColdWater = 21,
                HotWater = 31,
                UserId = 1
            };
            apartmentRepositoryMock.Setup(pr => pr.Get(1)).Returns(existingProduct);
            apartmentRepositoryMock.Setup(pr => pr.Get(2)).Returns(existingProduct2);
            apartmentRepositoryMock.Setup(pr => pr.GetApartmentByApNr(3)).Returns(existingProduct);
            apartmentRepositoryMock.Setup(pr => pr.GetApartmentByApNr(6)).Returns(existingProduct2);
            apartmentRepositoryMock.Setup(pr => pr.GetApartmentByTenantName("Testx")).Returns(existingProduct);
            apartmentRepositoryMock.Setup(pr => pr.GetApartmentByTenantName("Test")).Returns(existingProduct2);

        }

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
            Assert.AreEqual(132, calculateWaterPay);

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
        [TestMethod]
        public void GetApartment_Returns_CorrectApartmentWithGivenId()
        {
            //arrange
            ApartmentService service = new ApartmentService(apartmentRepositoryMock.Object);
            //act
            var apartment = service.GetApartment(1);

            //assert
            Assert.IsNotNull(apartment);
            Assert.AreEqual(1, apartment.Id);
            Assert.AreEqual("Testx", apartment.TenantName);
        }
        [TestMethod]
        public void GetApartmentByApNumber_Returns_CorrectApartmentWithGivenApNumber()
        {
            //arrange
            ApartmentService service = new ApartmentService(apartmentRepositoryMock.Object);
            //act
            var apartment = service.GetApartmentByApNumber(3);

            //assert
            Assert.IsNotNull(apartment);
            Assert.AreEqual(1, apartment.Id);
            Assert.AreEqual(3, apartment.ApNumber);
        }
        [TestMethod]
        public void GetApartmentByTenantName_Returns_CorrectApartmentWithGivenTenantName()
        {
            //arrange
            ApartmentService service = new ApartmentService(apartmentRepositoryMock.Object);
            //act
            var apartment = service.GetApartmentByTenantName("Test");

            //assert
            Assert.IsNotNull(apartment);
            Assert.AreEqual(2, apartment.Id);
            Assert.AreEqual("Test", apartment.TenantName);
        }
    }
}