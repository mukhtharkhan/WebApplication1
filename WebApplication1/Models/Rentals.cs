using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Rentals
    {
        public int Id { get; set; }

        // Foreign key to Customer table
        [ForeignKey("Customer")]
        public int CustId { get; set; }

        // Foreign key to car table
        [ForeignKey("Cars")]
        public int CarId { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime ReceiveDate { get; set; }

        public int StartMeterReading { get; set; }
        public int EndMeterReading { get; set; }

        public virtual Cars? Cars { get; set; }

        public virtual Customer? Customer { get; set; }

    }
}
