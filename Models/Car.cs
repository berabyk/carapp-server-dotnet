using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarAPI.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string model { get; set; }
        public string brand { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Light? Light { get; set; }
    }
}
