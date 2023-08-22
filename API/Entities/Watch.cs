using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Watch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ItemNumber { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }

        //Movement
        public string Caliber { get; set; }
        public string Movement { get; set; }
        public string Chronograph { get; set; }
        public int Jewel { get; set; }

        //Dimensions
        public float Weight { get; set; }
        public float Diameter { get; set; }
        public float Thickness { get; set; }
        public float Height { get; set; }

        public string CaseMaterial { get; set; }
        public string StrapMaterial { get; set; }

        public string PhotoUri { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
