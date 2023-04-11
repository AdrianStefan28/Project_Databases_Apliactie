namespace MTAApp.Models
{
    public class Employee : ModelEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Type { get; set;}
        public int? CNP { get; set;}
        public int? Age { get; set;}
        public double? ContractDuration { get; set;}
        public double? Salary { get; set;}
        public int AssociationId { get; set; }
        public Association? Association { get; set;} 
    }
}
