using Paraph_Food.Application.Services.Common.FileUploader;

namespace Paraph_Food.Application.Services.Products.Commands.EditCategoryService
{
    public class EditCategoryDto
    {
        public long ModifierUserId { get; set; }
        public string Title { get; set; }
        public long PackingCost { get; set; }
        public int Order { get; set; }
        public FileModel Image { get; set; }
    }
}
