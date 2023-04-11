namespace MTAApp.Models
{
    public class Apartment : ModelEntity
    {
        public int? ApNumber { get; set; }
        public string? TenantName { get; set; }
        public int? NoPeople { get; set; }
        public int? NoRooms { get; set; }
        public double? ColdWater { get; set; }
        public double? HotWater { get; set; }
        public double? ExtraPayments { get; set;}
        public double? CurrentMonthPayment { get; set; }
        public double? TotalPaymentDebt { get; set; }

        public int UserId { get; set; }
        public int AssociationId { get; set; }

        public User? User { get; set; }
        public Association? Association { get; set; }

    }
}
