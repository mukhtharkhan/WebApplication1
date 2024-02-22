using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }

        public string CarName { get; set; }

        public string CarModel { get; set; }

        public int MakeYear { get; set; }

        public virtual ICollection<CarImages> CarImages { get; set; }

    }
}
