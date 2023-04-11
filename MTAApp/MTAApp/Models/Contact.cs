namespace MTAApp.Models
{
    public class Contact : ModelEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Context { get; set; }

        public int AssociationId { get; set; }

        public Association? Association { get; set; }
    }
}
