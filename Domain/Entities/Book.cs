namespace Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
