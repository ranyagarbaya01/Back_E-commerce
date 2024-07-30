using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.Models
{
    public class Commande
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public DateTime Date { get; set; }
        public DateTime Heure { get; set; }

        public List<DétailsCommande> Items { get; set; } = new List<DétailsCommande>();

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalTTC { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalTVA { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalHT { get; set; }

        [Required]
        [Column(TypeName ="int")]
        public int FraisLivraison { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Status { get; set; }

        [ForeignKey("User")]
        public int idUser { get; set; }
        public User? User { get; set; }
        [ForeignKey("Address")]
        public int idAddress { get; set; }
        public Address? Address { get; set; }

    }
}
