using MTAApp.DataAccess.Model;
using MTAApp.Logic;

namespace MTAApp.UnitTests.Stefan
{
    [TestClass]
    public class ContractServiceTests
    {
        [TestMethod]
        public void CalculateTotalContractCost_Return_ProductBetweenContractDurationAndCost()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            Contract c = new Contract()
            {
                Id = 1,
                Type = "Electricitate",
                SupplierName = "ENEL",
                ContractDuration = 6,
                Cost = 200,
                AssociationId = 1
            };

            ContractService service = new ContractService(null);

            //Act
            //execute the code to be tested
            var calculatedTotalContractCost = service.CalculateTotalContractCost(c);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual(1200, calculatedTotalContractCost);

        }

        [TestMethod]
        public void SetContractDuration_SetANewContractDuration()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            Contract c = new Contract()
            {
                Id = 1,
                Type = "Electricitate",
                SupplierName = "ENEL",
                ContractDuration = 6,
                Cost = 200,
                AssociationId = 1
            };

            ContractService service = new ContractService(null);

            //Act
            //execute the code to be tested
            service.SetContractDuration(c, 12);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual(12, c.ContractDuration);

        }

    }
}
