namespace PRN222_DreamsCar.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<Book> Books { get; set; }
    }

}
