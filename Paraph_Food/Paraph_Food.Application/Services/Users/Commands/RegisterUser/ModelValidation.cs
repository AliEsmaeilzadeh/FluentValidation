using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Commands.RegisterUser
{
    public static class ModelValidation
    {
        public static bool IsValid(this RegisterUserDto model, out string message)
        {
            message = null;
            var valid = true;
            if (model.UserName.Length > 50)
            {
                message = "طول نام کاربری نمی تواند بیشتر از 50 کاراکتر باشد";
                return false;
            }
            return valid;
        }
    }
}
