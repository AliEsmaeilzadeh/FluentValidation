using Paraph_Food.Application.Services.Common.FileUploader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.Admin.Models.ViewModels.Products.Categories
{
    public class EditCategoryViewModel
    {
        public string Title { get; set; }
        public FileModel Image { get; set; }
        public long PackingCost { get; set; }
        public int Order { get; set; }
    }
}
