namespace PhoneBookTestApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
