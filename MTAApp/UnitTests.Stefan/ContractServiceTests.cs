using MTAApp.DataAccess.Model;
using MTAApp.Logic;
using Moq;
using MTAApp.DataAccess.Abstractions;

namespace MTAApp.UnitTests.Stefan
{
    [TestClass]
    public class ContractServiceTests
    {
        private Mock<IContractRepository> contractRepositoryMock = new Mock<IContractRepository>();

        [TestInitialize]
        public void InitializeTests()
        {
            Contract existingContract = new Contract
            {
                Id = 1,
                Type = "Electricitate",
                SupplierName = "ENEL",
                ContractDuration = 6,
                Cost = 200,
                AssociationId = 1
            };

            Contract existingContract2 = new Contract
            {
                Id = 2,
                Type = "Salubrizare",
                SupplierName = "IRIDEX",
                ContractDuration = 8,
                Cost = 100,
                AssociationId = 1
            };
            contractRepositoryMock.Setup(c => c.Get(1)).Returns(existingContract);
            contractRepositoryMock.Setup(c => c.Get(2)).Returns(existingContract);
        }

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

        [TestMethod]
        public void GetContract_Returns_CorrectContractWithGivenId()
        {
            //arrange
            ContractService service = new ContractService(contractRepositoryMock.Object);
            //act
            var contract = service.GetContract(1);

            //assert
            Assert.IsNotNull(contract);
            Assert.AreEqual(1, contract.Id);
            Assert.AreEqual("ENEL", contract.SupplierName);
        }


        [TestMethod]
        public void GetContractByType_Returns_CorrectFirstContractWithGivenType()
        {
            //arrange
            ContractService service = new ContractService(contractRepositoryMock.Object);
            //act
            var contract = service.GetContractByType("Electricitate");

            //assert
            Assert.IsNotNull(contract);
            Assert.AreEqual(1, contract.Id);
            Assert.AreEqual("ENEL", contract.SupplierName);
            Assert.AreEqual("Electricitate", contract.Type);
        }

    }
}
