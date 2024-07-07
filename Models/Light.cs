using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarAPI.Models
{
    public class Light
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LightId { get; set; }
        public string HeadLights { get; set; }
        public string FogLights { get; set; }
        public int Angle { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [JsonIgnore]
        public Car? Car { get; set; }
    }
}
