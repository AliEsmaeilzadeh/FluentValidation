using Paraph_Food.Application.Services.Common.InEnum;
using System;
using System.Collections.Generic;
using System.Text;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Products.Commands.EditProductService
{
    public static class ModelValidation
    {
        public static bool IsValid(this EditProductDto model, out string message)
        {
            message = null;
            var valid = true;
            if (model.ModifierUserId <= 0)
            {
                message = "شناسه کاربر ویرایش کننده محصول باید مشخص شود";
                return false;
            }
            if (model.CategoryId <= 0)
            {
                message = "دسته مربوط به این محصول باید مشخص شود";
                return false;
            }
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                message = "نام محصول باید مشخص شود";
                return false;
            }
            if (model.Title?.Length > 50)
            {
                message = "طول نام محصول نمی تواند بیشتر از 50 کاراکتر باشد";
                return false;
            }
            if (!string.IsNullOrWhiteSpace(model.Ingredients) && model.Ingredients.Length > 200)
            {
                message = "طول عناصر نمی تواند بیشتر از 200 کاراکتر باشد";
                return false;
            }
            if (model.Price < 0)
            {
                message = "قیمت محصول نمی تواند منفی باشد";
                return false;
            }
            if (model.DiscountValue < 0)
            {
                message = "میزان تخفیف محصول نمی تواند منفی باشد";
                return false;
            }
            if (!model.DiscountValueType.InEnum(typeof(DiscountValueType)))
            {
                message = "نوع مقدار تخفیف بدرستی مشخص شود";
                return false;
            }
            return valid;
        }

    }
}
