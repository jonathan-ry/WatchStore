using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.DTO
{
    public class WatchDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ItemNumber { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string FullDescription { get; set; }

        //Movement
        [Required]
        public string Caliber { get; set; }
        [Required]
        public string Movement { get; set; }
        [Required]
        public string Chronograph { get; set; }
        [Required]
        public int Jewel { get; set; }

        //Dimensions
        [Required]
        public float Weight { get; set; }
        [Required]
        public float Diameter { get; set; }
        [Required]
        public float Thickness { get; set; }
        [Required]
        public float Height { get; set; }

        [Required]
        public string CaseMaterial { get; set; }
        [Required]
        public string StrapMaterial { get; set; }

        [JsonIgnore]
        public IFormFile Photo { get; set; }
    }
}
