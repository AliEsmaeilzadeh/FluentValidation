using Paraph_Food.Application.Services.Common.FileUploader;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Products.Commands.AddCategoryService
{
    public class AddCategoryDto
    {
        public long CreatedUserId { get; set; }
        public string Title { get; set; }
        public FileModel Image { get; set; }
        public long PackingCost { get; set; }
        public int Order { get; set; }
    }
}
