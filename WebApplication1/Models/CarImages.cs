using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CarImages
    {
        public int Id { get; set; }

        // Foreign key to car table
        [ForeignKey("Cars")]
        public int CarId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Cars? Cars { get; set; }
    }
}
