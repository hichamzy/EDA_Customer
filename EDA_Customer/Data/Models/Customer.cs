namespace EDA_Customer.Data.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ProductId { get; set; }

        public int ItemInCart { get; set; }

    }
}
