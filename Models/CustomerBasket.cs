using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.Models
{
    public class CustomerBasket
    {
        
        [Key]
        public string Id { get; set; }
       
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        [Column(TypeName = "int")]

        public int? DeliveryMethodId { get; set; }
        [Column(TypeName = "nvarchar(255)")]

        public string? ClientSecret { get; set; }
        [Column(TypeName = "nvarchar(255)")]

        public string? PaymentIntentId { get; set; }
        [Column(TypeName = "decimal(18,3)")]

        public decimal ShippingPrice { get; set; }
    }
}
