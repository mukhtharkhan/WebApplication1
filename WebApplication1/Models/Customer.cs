namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Cust_Name { get; set; }

        public string Id_Number { get; set; }

        public int PhoneNumber { get; set; }

        public virtual ICollection<Rentals> Rentals { get; set; }
    }
}
