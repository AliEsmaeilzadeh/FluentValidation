using Paraph_Food.Application.Common.AppSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Paraph_Food.Application.Services.Common.FileRremover
{
    public static class FileRemover
    {
        public static void RemoveProfileImage(this string fileName, AppSettings _appSettings)
        {
            if(!string.IsNullOrWhiteSpace(fileName))
            {
                var directory = WebRoot.Path + _appSettings.Files.UploadBaseUrl + _appSettings.Files.Category.ProfileImages;
                var filePath = directory + fileName;
                if (File.Exists(filePath))
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }
            }
        }
        public static void RemoveCategoryImage(this string fileName, AppSettings _appSettings)
        {
            if(!string.IsNullOrWhiteSpace(fileName))
            {
                var directory = WebRoot.Path + _appSettings.Files.UploadBaseUrl + _appSettings.Files.Category.CategoryImages;
                var filePath = directory + fileName;
                if (File.Exists(filePath))
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }
            }
        }
    }
}
