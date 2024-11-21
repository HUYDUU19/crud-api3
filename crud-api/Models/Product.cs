using System.ComponentModel.DataAnnotations;

namespace crud_api.Models
{
    public class Product
    {
         
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string? Qty { get; set; }
    }
}
