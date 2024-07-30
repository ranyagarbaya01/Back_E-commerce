using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace store.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "int")]
        public int type { get; set; } = 0;

        [Column(TypeName = "nvarchar(255)")]
        public string? token { get; set; } = "";

    }
}
