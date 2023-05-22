using Moq;
using MTAApp.DataAccess.Model;
using MTAApp.Logic;
using MTAApp.DataAccess.Abstractions;

namespace MTAApp.UnitTest.Trifu
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> employeeRepositoryMock = new Mock<IEmployeeRepository>();
        [TestInitialize]
        public void InitializeTests()
        {
            Employee existingEmployee = new Employee
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test2",
                Type = "TestType",
                ContractDuration = 6,
                Salary = 250,
                AssociationId = 1
            };
            Employee existingEmployee2 = new Employee
            {
                Id = 2,
                FirstName = "Testtest",
                LastName = "Test22",
                Type = "TestType2",
                ContractDuration = 10,
                Salary = 300,
                AssociationId = 1
            };
            employeeRepositoryMock.Setup(pr => pr.Get(1)).Returns(existingEmployee);
            employeeRepositoryMock.Setup(pr => pr.Get(2)).Returns(existingEmployee2);
            employeeRepositoryMock.Setup(pr => pr.GetEmployeeByType("TestType")).Returns(existingEmployee);
            employeeRepositoryMock.Setup(pr => pr.GetEmployeeByType("TestType2")).Returns(existingEmployee2);
            employeeRepositoryMock.Setup(pr => pr.GetEmployeeByName("Test","Test2")).Returns(existingEmployee);
            employeeRepositoryMock.Setup(pr => pr.GetEmployeeByName("Testtest", "Test22")).Returns(existingEmployee2);

        }
        [TestMethod]
        public void CalculateEmployeeTotalPay_Return_ProductBetweenContractDurationAndSalary()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            Employee n = new Employee()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test2",
                Type = "TestType",
                ContractDuration = 6,
                Salary = 250,
                AssociationId = 1
            };

            EmployeeService service = new EmployeeService(null);

            //Act
            //execute the code to be tested
            var calculateEmployeeTotalPay = service.CalculateEmployeeTotalPay(n);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual(1500, calculateEmployeeTotalPay);

        }
        [TestMethod]
        public void GetEmployeeType_Return_EmployeeType()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            Employee n = new Employee()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test2",
                Type = "Plumber",
                ContractDuration = 6,
                Salary = 250,
                AssociationId = 1
            };

            EmployeeService service = new EmployeeService(null);

            //Act
            //execute the code to be tested
            var getEmployeeType = service.GetEmployeeType(n);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual("Plumber", getEmployeeType);

        }
        [TestMethod]
        public void SetEmployeeSalary_Set_NewEmployeeSalary()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            Employee n = new Employee()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test2",
                Type = "Plumber",
                ContractDuration = 6,
                Salary = 250,
                AssociationId = 1
            };

            EmployeeService service = new EmployeeService(null);

            //Act
            //execute the code to be tested
            service.SetEmployeeSalary(n, 300);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual(300, n.Salary);

        }

        [TestMethod]
        public void GetEmployee_Returns_CorrectEmployeeWithGivenId()
        {
            //arrange
            EmployeeService service = new EmployeeService(employeeRepositoryMock.Object);
            //act
            var employee = service.GetEmployee(1);

            //assert
            Assert.IsNotNull(employee);
            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("Test", employee.FirstName);
        }
        [TestMethod]
        public void GetEmployeeByType_Returns_CorrectEmployeeWithGivenType()
        {
            //arrange
            EmployeeService service = new EmployeeService(employeeRepositoryMock.Object);
            //act
            var employee = service.GetEmployeeByType("TestType");

            //assert
            Assert.IsNotNull(employee);
            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("Test", employee.FirstName);
        }
        [TestMethod]
        public void GetEmployeeByName_Returns_CorrectEmployeeWithGivenName()
        {
            //arrange
            EmployeeService service = new EmployeeService(employeeRepositoryMock.Object);
            //act
            var employee = service.GetEmployeeByName("Test", "Test2");

            //assert
            Assert.IsNotNull(employee);
            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("Test", employee.FirstName);
        }
    }
}