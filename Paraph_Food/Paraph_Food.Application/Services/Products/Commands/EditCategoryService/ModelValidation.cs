using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Products.Commands.EditCategoryService
{
    public static class ModelValidation
    {
        public static bool IsValid(this EditCategoryDto model, out string message)
        {
            message = null;
            var valid = true;

            if (model.ModifierUserId <= 0)
            {
                message = "شناسه کاربر ویرایش کننده دسته باید مشخص شود";
                return false;
            }
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                message = "فیلد عنوان دسته نمی تواند خالی باشد";
                return false;
            }
            if (model.Title.Length > 50)
            {
                message = "طول عنوان دسته نمی تواند بیشتر از 50 کاراکتر باشد";
                return false;
            }
            if (model.PackingCost < 0)
            {
                message = "فیلد هزینه دسته نمیتواند منفی باشد";
                return false;
            }
            return valid;
        }
    }
}
