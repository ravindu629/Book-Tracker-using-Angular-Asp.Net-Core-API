using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI.Models
{
    public class BookDetail
    {
        [Key]
        public int BookId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string title { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string author { get; set; } = "";

        [Column(TypeName = "nvarchar(13)")]
        public string isbn { get; set; } = "";

        //mm/yy
        [Column(TypeName = "nvarchar(5)")]
        public string publicationDate { get; set; } = "";

    }
}
