using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGameWebApp.Models
{
    public class VideoGame
    {
        public int ID { get; set; }
        public String? Title { get; set; }

        public String? Genre { get; set; }

        public String? Platform { get; set; }

        public String? Publisher { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string Rating { get; set; } = string.Empty;


    }
}
