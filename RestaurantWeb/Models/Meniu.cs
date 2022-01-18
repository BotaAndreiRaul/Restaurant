using System.ComponentModel.DataAnnotations;

namespace RestaurantWeb.Models
{
    public class Meniu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
