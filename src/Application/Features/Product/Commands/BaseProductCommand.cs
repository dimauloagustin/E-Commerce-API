namespace Application.Features.Product.Commands
{
    public abstract class BaseProductCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public double Discount { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
