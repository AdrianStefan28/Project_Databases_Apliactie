namespace MTAApp.Models
{
    public class User : ModelEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Type { get; set; }

        public ICollection<Apartment>? Apartments { get; set; }
        public ICollection<Poll>? Polls { get; set; }

        public int AssociationId { get; set; }
        public Association? Association { get; set; }
        
    }
}
