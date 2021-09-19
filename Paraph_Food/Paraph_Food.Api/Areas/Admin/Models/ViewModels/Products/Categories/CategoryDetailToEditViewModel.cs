using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.Admin.Models.ViewModels.Products.Categories
{
    public class CategoryDetailToEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long PackingCost { get; set; }
        public int Order { get; set; }
        public string Image { get; set; }

    }
}
