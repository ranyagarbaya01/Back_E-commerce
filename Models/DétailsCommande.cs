using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace store.Models
{
    public class DétailsCommande
    {

        [Key]
        public int Id { get; set; }
       

        [Required]
        [Column(TypeName = "int")]
        public int Qte { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal PrixUnitaire { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal PrixTotal { get; set; }

        [ForeignKey("Produit")]
        public int idProduit { get; set; }
        public Produit? Produit { get; set; }

       
    }
}
