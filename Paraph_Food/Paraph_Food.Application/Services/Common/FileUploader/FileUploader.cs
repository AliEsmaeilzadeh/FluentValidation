using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using System;
using System.IO;

namespace Paraph_Food.Application.Services.Common.FileUploader
{
    public static class FileUploader
    {
        public static UploadResultDto UploadToProfile(this FileModel file, AppSettings _appSettings)
        {

            if (file != null)
            {
                var fileType = ".jpg";
                var name = CodeGenerators.CodeGenerator.generateNumeralCode(1000, 9999) + "_" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                name = name + fileType;

                var directory = WebRoot.Path + _appSettings.Files.UploadBaseUrl + _appSettings.Files.Category.ProfileImages;

                Directory.CreateDirectory(directory);
                var filePath = Path.Combine(directory, name);

                var base64array = Convert.FromBase64String(file.Base64File);

                File.WriteAllBytes(filePath, base64array);

                return new UploadResultDto()
                {
                    IsSuccess = true,
                    FileName = "/" + name,
                };
            }

            return new UploadResultDto()
            {
                IsSuccess = true,
                FileName = null
            };
        }
        public static UploadResultDto UploadToCategory(this FileModel file, AppSettings _appSettings)
        {
            if (file != null)
            {
                var fileType = ".jpg";
                var name = CodeGenerators.CodeGenerator.generateNumeralCode(1000, 9999) + "_" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                name = name + fileType;

                var directory = WebRoot.Path + _appSettings.Files.UploadBaseUrl + _appSettings.Files.Category.CategoryImages;

                Directory.CreateDirectory(directory);
                var filePath = Path.Combine(directory, name);

                var base64array = Convert.FromBase64String(file.Base64File);

                File.WriteAllBytes(filePath, base64array);

                return new UploadResultDto()
                {
                    IsSuccess = true,
                    FileName = "/" + name,
                };
            }

            return new UploadResultDto()
            {
                IsSuccess = true,
                FileName = null
            };
        }
        public static UploadResultDto UploadToProducts(this FileModel file, AppSettings _appSettings)
        {
            if (file != null)
            {
                var fileType = ".jpg";
                var name = CodeGenerators.CodeGenerator.generateNumeralCode(1000, 9999) + "_" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                name = name + fileType;

                var directory = WebRoot.Path + _appSettings.Files.UploadBaseUrl + _appSettings.Files.Category.ProductImages;

                Directory.CreateDirectory(directory);
                var filePath = Path.Combine(directory, name);

                var base64array = Convert.FromBase64String(file.Base64File);

                File.WriteAllBytes(filePath, base64array);

                return new UploadResultDto()
                {
                    IsSuccess = true,
                    FileName = "/" + name,
                };
            }

            return new UploadResultDto()
            {
                IsSuccess = true,
                FileName = null
            };
        }
    }
}
