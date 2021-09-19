using Paraph_Food.Application.Services.Common.FileUploader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Api.Areas.Admin.Models.ViewModels.Products.Products
{
    public class EditProductViewModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public long Price { get; set; }
        public FileModel Image { get; set; }
        public double DiscountValue { get; set; }
        public DiscountValueType DiscountValueType { get; set; }
    }
}
