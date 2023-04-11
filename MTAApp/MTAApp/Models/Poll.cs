namespace MTAApp.Models
{
    public class Poll : ModelEntity
    {
        public string? Subject { get; set; }
        public string? Context { get; set; }
        public int UserId { get; set; } 

        public User? User { get; set; }

    }
}
