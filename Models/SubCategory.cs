namespace PRN222_DreamsCar.Models
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; }
        public string Name { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<Book> Books { get; set; }
    }

}
