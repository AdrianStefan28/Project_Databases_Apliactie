namespace MTAApp.DataAccess.Model
{
    public class Contract : ModelEntity
    {
        public string? Type { get; set; }
        public string? SupplierName { get; set; }
        public double? ContractDuration { get; set; }
        public double? Cost { get; set; }
        public int AssociationId { get; set; }
        public Association? Association { get; set; }    
    }
}
