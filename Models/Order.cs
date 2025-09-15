using System.ComponentModel.DataAnnotations;

namespace PRN222_BookShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public decimal TotalAmount { get; set; }

        public string? ShippingAddress { get; set; }

        // Trạng thái: Process, Completed
        public string Status { get; set; } = "Process";

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
