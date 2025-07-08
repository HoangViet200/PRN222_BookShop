namespace PRN222_DreamsCar.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }

        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int SubCategoryID { get; set; }
        public SubCategory SubCategory { get; set; }

        public string? ISBN { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? PageCount { get; set; }
        public decimal? Weight { get; set; }
        public string? Dimensions { get; set; }

    }

}
