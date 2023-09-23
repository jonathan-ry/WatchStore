using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; } = String.Empty;
        [Required(ErrorMessage = "This field is required.")]
        public string ItemNumber { get; set; } = String.Empty;
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string FullDescription { get; set; }

        //Movement
        [Required(ErrorMessage = "This field is required.")]
        public string Caliber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Movement { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Chronograph { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Range(1, 70, ErrorMessage = "Enter a value between 1-70")]
        public int? Jewel { get; set; }

        //Dimensions
        [Required(ErrorMessage = "This field is required.")]
        [Range(2.0, 200.0, ErrorMessage = "Enter a value between 2.0-200.0")]
        public float Weight { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Range(25.0, 55.0, ErrorMessage = "Enter a value between 25.0-55.0")]
        public float Diameter { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Range(2.0, 20.0, ErrorMessage = "Enter a value between 2.0-20.0")]
        public float Thickness { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Range(25.0, 55.0, ErrorMessage = "Enter a value between 25.0-55.0")]
        public float Height { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string CaseMaterial { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string StrapMaterial { get; set; }

        public IFormFile Photo { get; set; }
    }
}
