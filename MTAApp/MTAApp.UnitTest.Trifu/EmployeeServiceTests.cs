using MTAApp.DataAccess.Model;
using MTAApp.Logic;
namespace MTAApp.UnitTest.Trifu
{
    [TestClass]
    public class EmployeeServiceTests
    {
        [TestMethod]
        public void CalculateEmployeeTotalPay_Return_ProductBetweenContractDurationAndSalary()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            Employee n = new Employee()
            {
                Id = 1,
                FirstName= "Test",
                LastName= "Test2",
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
            service.SetEmployeeSalary(n,300);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual(300, n.Salary);

        }
    }
}