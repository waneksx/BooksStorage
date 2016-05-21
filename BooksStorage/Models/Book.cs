using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksStorage.Models
{
    public class Book
    {
        [Key]
        [Column("BookId")]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Small title")]
        [MaxLength(100, ErrorMessage = "Big title")]
        public string Title { get; set; }

       
        public Author Author { get; set; }
    }
}