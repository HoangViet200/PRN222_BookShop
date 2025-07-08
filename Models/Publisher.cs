namespace PRN222_DreamsCar.Models
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }

}
