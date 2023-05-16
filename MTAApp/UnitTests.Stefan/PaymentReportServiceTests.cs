using MTAApp.DataAccess.Model;
using MTAApp.Logic;
using Moq;
using MTAApp.DataAccess.Abstractions;

namespace MTAApp.UnitTests.Stefan
{
    [TestClass]
    public class PaymentReportServiceTests
    {
        private Mock<IPaymentReportRepository> paymentReportRepositoryMock = new Mock<IPaymentReportRepository>();

        [TestInitialize]
        public void InitializeTests()
        {
            PaymentReport existingPaymentReport = new PaymentReport
            {
                Id = 1,
                Expense = 200,
                Income = 500,
                Profit = 300,
                AssociationId = 1
            };
            PaymentReport existingPaymentReport2 = new PaymentReport
            {
                Id = 2,
                Expense = 400,
                Income = 500,
                Profit = 100,
                AssociationId = 1
            };
            paymentReportRepositoryMock.Setup(pr => pr.Get(1)).Returns(existingPaymentReport);
            paymentReportRepositoryMock.Setup(pr => pr.Get(2)).Returns(existingPaymentReport2);
        }

        [TestMethod]
        public void CalculateProfit_Return_DifferenceBetweenIncomesAndExpenses()
        {
            //AAA
            //Arrange
            //preparing the data for testing
            PaymentReport p = new PaymentReport()
            {
                Id = 1,
                Expense = 200,
                Income = 500,
                AssociationId = 1
            };

            PaymentReportService service = new PaymentReportService(null);

            //Act
            //execute the code to be tested
            var calculatedProfit = service.CalculateProfit(p);

            //Assert
            //verify the result to comply with the expected value/s
            Assert.AreEqual(300, calculatedProfit);

        }

        [TestMethod]
        public void GetPaymentReport_Returns_CorrectPaymentReportWithGivenId()
        {
            //arrange
            PaymentReportService service = new PaymentReportService(paymentReportRepositoryMock.Object);
            //act
            var paymentReport = service.GetPaymentReport(1);

            //assert
            Assert.IsNotNull(paymentReport);
            Assert.AreEqual(1, paymentReport.Id);
        }

        [TestMethod]
        public void GetPaymentReportByProfit_Returns_FirstCorrectPaymentReportWithGivenProfit()
        {
            //arrange
            PaymentReportService service = new PaymentReportService(paymentReportRepositoryMock.Object);
            //act
            var paymentReport = service.GetPaymentReportByProfit(300);

            //assert
            Assert.IsNotNull(paymentReport);
            Assert.AreEqual(1, paymentReport.Id);
            Assert.AreEqual(300, paymentReport.Profit);
        }

    }
}