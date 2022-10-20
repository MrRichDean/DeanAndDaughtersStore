using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities.Models
{
    public class Book
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public double? Price { get; set; }
    }


}
