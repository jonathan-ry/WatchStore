using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels
{
    public class UpdateViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string ItemNumber { get; set; } = String.Empty;
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Required]
        public string? ShortDescription { get; set; }
        [Required]
        public string? FullDescription { get; set; }

        //Movement
        [Required]
        public string? Caliber { get; set; }
        [Required]
        public string? Movement { get; set; }
        [Required]
        public string? Chronograph { get; set; }
        [Required]
        [Range(1, 70, ErrorMessage = "Enter a value between 1-70")]
        public int? Jewel { get; set; }

        //Dimensions
        [Required]
        [Range(2.0, 200.0, ErrorMessage = "Enter a value between 2.0-200.0")]
        public float? Weight { get; set; }
        [Required]
        [Range(25.0, 55.0, ErrorMessage = "Enter a value between 25.0-55.0")]
        public float? Diameter { get; set; }
        [Required]
        [Range(2.0, 20.0, ErrorMessage = "Enter a value between 2.0-20.0")]
        public float? Thickness { get; set; }
        [Required]
        [Range(25.0, 55.0, ErrorMessage = "Enter a value between 25.0-55.0")]
        public float? Height { get; set; }

        [Required]
        public string? CaseMaterial { get; set; }
        [Required]
        public string? StrapMaterial { get; set; }
        public string? PhotoUri { get; set; }

        public IFormFile? Photo { get; set; }
    }
}
