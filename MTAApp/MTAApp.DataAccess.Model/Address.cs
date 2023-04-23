namespace MTAApp.DataAccess.Model
{
    public class Address : ModelEntity
    {
        public string? Address1 { get; set; } 
        public string? City { get; set; }
        public string? State { get; set; }

        public int AssociationId { get; set; }

        public Association? Association { get; set; }
    }
}
