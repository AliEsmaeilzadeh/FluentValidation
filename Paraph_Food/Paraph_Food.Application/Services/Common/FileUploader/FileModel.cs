namespace Paraph_Food.Application.Services.Common.FileUploader
{
    public class FileModel
    {
        public string Base64File { get; set; }
        public string FileName { get; set; }
        public string FileTypeName { get; set; }
        public double Size { get; set; }
        public byte SizeUnitTypeId { get; set; }
        public bool Edited { get; set; }
    }
}
