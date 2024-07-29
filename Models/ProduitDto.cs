using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.Models
{
    public class ProduitDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
      
       
        public string Description { get; set; } = "";

        public decimal PrixHT { get; set; }

        public decimal PrixTTC { get; set; }
        public decimal TVA { get; set; }

        public int FamilleId { get; set; }
                
    
        public int TypeId { get; set; }
        public IFormFile imageFile { get; set; }

    }
}
