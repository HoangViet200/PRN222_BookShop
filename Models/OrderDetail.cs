using PRN222_DreamsCar.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN222_BookShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        [Required]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [Required]
        public int BookID { get; set; }
        public Book Book { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
