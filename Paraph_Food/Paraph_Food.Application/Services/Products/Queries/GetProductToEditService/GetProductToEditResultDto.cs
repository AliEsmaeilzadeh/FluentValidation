using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Products.Queries.GetProductToEditService
{
    public class GetProductToEditResultDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public long Price { get; set; }
        public string Image { get; set; }
        public double DiscountValue { get; set; }
        public DiscountValueType DiscountValueType { get; set; }
    }
}
