using MTAApp.DataAccess.Model;
using MTAApp.Logic;

namespace MTAApp.UnitTests.Stefan
{
    [TestClass]
    public class PaymentReportServiceTests
    {
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

    }
}