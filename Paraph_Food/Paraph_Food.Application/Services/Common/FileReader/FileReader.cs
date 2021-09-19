using Paraph_Food.Application.Common.AppSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Common.FileReader
{
    public static class FileReader
    {
        public static string GetProfileImageAddress(this string imageName, AppSettings _appSettings)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;

            var imageAddress = _appSettings.Files.DownloadBaseUrl + _appSettings.Files.Category.ProfileImages + imageName;
            return imageAddress;
        }
        public static string GetCategoryImageAddress(this string imageName, AppSettings _appSettings)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;

            var imageAddress = _appSettings.Files.DownloadBaseUrl + _appSettings.Files.Category.CategoryImages + imageName;
            return imageAddress;
        }
        public static string GetProductImageAddress(this string imageName, AppSettings _appSettings)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;

            var imageAddress = _appSettings.Files.DownloadBaseUrl + _appSettings.Files.Category.ProductImages + imageName;
            return imageAddress;
        }
    }
}
