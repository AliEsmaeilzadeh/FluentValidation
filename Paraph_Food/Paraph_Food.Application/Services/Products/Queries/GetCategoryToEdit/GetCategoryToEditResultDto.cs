using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Products.Queries.GetCategoryToEdit
{
    public class GetCategoryToEditResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long PackingCost { get; set; }
        public int Order { get; set; }
        public string Image { get; set; }
    }
}
