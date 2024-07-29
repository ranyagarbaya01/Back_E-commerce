using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.Models
{
    public class BasketItem
    {
        [Key]

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? PictureUrl { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Brand { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Type { get; set; }

    }
}
