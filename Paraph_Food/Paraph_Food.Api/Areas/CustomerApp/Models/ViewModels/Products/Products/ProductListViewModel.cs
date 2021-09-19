using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.CustomerApp.Models.ViewModels.Products.Products
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public long Price { get; set; }
        public long? DiscountedPrice { get; set; }
        public string Image { get; set; }
        public double Score { get; set; }
        public bool IsLiked { get; set; }
    }
}
