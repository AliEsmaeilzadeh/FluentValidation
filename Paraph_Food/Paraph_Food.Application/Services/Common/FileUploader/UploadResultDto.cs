using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Common.FileUploader
{
    public class UploadResultDto
    {
        public bool IsSuccess { get; set; }
        public string FileName { get; set; }
        public ErrorDto Exception { get; set; }
    }
}
