using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace store.Models
{
    public class Produit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; } = "";

        [Required]
        [Column(TypeName = "decimal(18,5)")]
        public decimal PrixHT { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,5)")]
        public decimal TVA { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        [RegularExpression(@"\d+(\.\d{1,6})?", ErrorMessage = "PrixTTC must have up to 3 decimal places.")]
        public decimal PrixTTC { get; set; }

        [ForeignKey("Famille")]
        public int? FamilleId { get; set; }
        public Famille Famille { get; set; }

        [ForeignKey("Type")]
        public int? TypeId { get; set; }
        public Type Type { get; set; }

        public byte[] image { get; set; }
        [NotMapped]
        public string ImageUrl { get; set; }
    }
}
