namespace MTAApp.Models
{
    public class PaymentReport : ModelEntity
    {
        public double? EmployeesSalary { get; set; }
        public double? ContractsCost { get; set; }
        public double? RepairingFund { get; set; }
        public double? AppsPayCurrentMonth { get; set; }
        public double? AppsTotalPayDebt { get; set; }
        public double? OtherPays { get; set; }
        public double? Expense { get; set; }
        public double? Income { get; set; }
        public double? Profit { get; set; }
        public int AssociationId { get; set; }

        public Association? Association { get; set; }
    }
}
