using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Bill
    {
        public int Id { get; set; }

        // Foreign key to car Rentals
        [ForeignKey("Rentals")]
        public int RentalId { get; set; }
        public DateTime BillGeneratedDate { get; set; }
        public DateTime PaidDate { get; set; }
        public string BillStatus { get; set; }

        public int Amount { get; set; }

        public virtual Rentals? Rentals { get; set; }
    }
}
