namespace MTAApp.DataAccess.Model

{
    public class Association : ModelEntity
    {
        public string? Name { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
        public ICollection<Employee>? Empoyees { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Contract>? Contracts { get; set; }

        public Address? Address { get; set; }
        public PaymentReport? PaymentReport { get; set; }

    }
}
