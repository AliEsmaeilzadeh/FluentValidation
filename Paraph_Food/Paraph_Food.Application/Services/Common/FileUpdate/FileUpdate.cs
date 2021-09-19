using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Common.FileRremover;
using Paraph_Food.Application.Services.Common.FileUploader;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Common.FileUpdate
{
    public static class FileUpdate
    {

        public static string UpdateProfileImageTo(this string oldFileName, FileModel newFile, AppSettings _appSettings)
        {
            // اگر کاربر تصویر پروفایلش را تغییر داده باشد
            if (newFile.Edited)
            {
                oldFileName.RemoveProfileImage(_appSettings);
                var result = newFile.UploadToProfile(_appSettings);

                return result.FileName;
            }
            // اگر کاربر تصویر پروفایلش را تغییر نداده باشد
            else
                return oldFileName;
        }
        public static string UpdateCategoryImageTo(this string oldFileName, FileModel newFile, AppSettings _appSettings)
        {
            // اگر کاربر تصویر دسته را تغییر داده باشد
            if (newFile.Edited)
            {
                oldFileName.RemoveCategoryImage(_appSettings);
                var result = newFile.UploadToCategory(_appSettings);

                return result.FileName;
            }
            // اگر کاربر تصویر دسته را تغییر نداده باشد
            else
                return oldFileName;
        }
    }
}
