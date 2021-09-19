using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Commands.EditCustomerProfile
{
    public static class ModelValidation
    {
        public static bool IsValid(this EditCustomerProfileDto model, out string message)
        {
            message = null;
            var valid = true;
            if (model.FirstName?.Length > 20)
            {
                message = "طول نام نمی تواند بیشتر از 20 کاراکتر باشد";
                return false;
            }
            if (model.LastName?.Length > 30)
            {
                message = "طول نام خانوادگی نمی تواند بیشتر از 30 کاراکتر باشد";
                return false;
            }
            return valid;
        }

    }
}
