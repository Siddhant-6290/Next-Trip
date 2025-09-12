using System.ComponentModel.DataAnnotations;

namespace TMS.Models
{
    public class TourPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }   
    }
}
