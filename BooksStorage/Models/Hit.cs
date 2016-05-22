using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksStorage.Models
{
    public class Hit
    {
        [Key]
        [Column("HitId")]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }


    }
}