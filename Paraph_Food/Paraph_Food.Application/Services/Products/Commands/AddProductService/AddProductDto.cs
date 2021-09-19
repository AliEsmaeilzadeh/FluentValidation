using Paraph_Food.Application.Services.Common.FileUploader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Products.Commands.AddProductService
{
    public class AddProductDto
    {
        public long CreatorUserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public long Price { get; set; }
        public FileModel Image { get; set; }
        public double DiscountValue { get; set; }
        public DiscountValueType DiscountValueType { get; set; }
    }
}
