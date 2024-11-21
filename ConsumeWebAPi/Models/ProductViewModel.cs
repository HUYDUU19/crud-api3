using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumeWebAPi.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]

        public required string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
