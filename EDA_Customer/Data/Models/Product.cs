namespace EDA_Customer.Data.Models
{
    public class Product

    {

        public int Id { get; set; }

        public Guid ProductId { get; set; }
        public string Name { get; set; }


        public int ItemInCart { get; set; }
    }

}
