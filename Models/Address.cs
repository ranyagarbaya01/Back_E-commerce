using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.Models
    

{
    public class Address
        
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string State { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]

        public string Street { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Zipcode { get; set; }
    }
}
