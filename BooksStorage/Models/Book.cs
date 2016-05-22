using Google.DataTable.Net.Wrapper;
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

        public IList<Hit> Hits { get; set; }

        public Book()
        {
            Hits = new List<Hit>();
        }

        public string GoogleChartData
        {
            get
            {

                //let's instantiate the DataTable.
                var dt = new Google.DataTable.Net.Wrapper.DataTable();
                dt.AddColumn(new Column(ColumnType.Date, "Day", "Day"));
                dt.AddColumn(new Column(ColumnType.Number, "Count", "Views"));

                foreach (Hit hit in Hits)
                {
                    Row r = dt.NewRow();
                    r.AddCellRange(new Cell[]
                    {
                        new Cell(hit.Date),
                        new Cell(hit.Count)
                    });
                    dt.AddRow(r);
                }

                //Let's create a Json string as expected by the Google Charts API.
                return dt.GetJson();
            }
        }
    }
}