using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksStorage.Models
{
    public class Author
    {
        [Key]
        [Column("AuthorId")]        
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Small first name")]
        [MaxLength(40, ErrorMessage = "Big first name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Small last name")]
        [MaxLength(40, ErrorMessage = "Big last name")]
        public string LastName { get; set; }
    }
}