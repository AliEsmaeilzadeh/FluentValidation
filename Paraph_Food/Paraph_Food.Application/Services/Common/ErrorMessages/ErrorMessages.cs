using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Common.ErrorMessages
{
    public class ErrorMessages
    {

        /// <summary>
        /// کد وارد شده نا معتبر است 1
        /// </summary>
        public static ErrorDto InValidVCodeException
        { 
            get 
            {
                return new ErrorDto(1, "کد وارد شده نا معتبر است");
            } 
        }

        /// <summary>
        /// کاربری با این شماره موبایل یافت نشد 2
        /// </summary>
        public static ErrorDto IncurrectCustomerMobileException
        { 
            get 
            {
                return new ErrorDto(2, "کاربری با این شماره موبایل یافت نشد");
            } 
        }

        /// <summary>
        /// حساب کاربری شما غیرفعال شده است  3
        /// </summary>
        public static ErrorDto UserIsDisabledException
        {
            get
            {
                return new ErrorDto(3, "حساب کاربری شما غیر فعال شده است");
            }
        }

        /// <summary>
        /// حساب کاربری شما مسدود شده است 4
        /// </summary>
        public static ErrorDto UserIsBlockedException
        {
            get
            {
                return new ErrorDto(3, "حساب کاربری شما مسدود شده است");
            }
        }

        /// <summary>
        /// حساب کاربری مورد نظر یافت نشد 5
        /// </summary>
        public static ErrorDto NoUserException
        {
            get
            {
                return new ErrorDto(5, "حساب کاربری مورد نظر یافت نشد");
            }
        }

        /// <summary>
        /// کلمه عبور صحیح نیست 6
        /// </summary>
        public static ErrorDto IncurectPasswordException
        {
            get
            {
                return new ErrorDto(6, "کلمه عبور صحیح نیست");
            }
        }

        /// <summary>
        /// نام کاربری صحیح نیست 7
        /// </summary>
        public static ErrorDto IncurectUserNameException
        {
            get
            {
                return new ErrorDto(7, "نام کاربری صحیح نیست");
            }
        }

        /// <summary>
        /// نقش نسبت داده شده به کاربر در سیستم وجود ندارد 8
        /// </summary>
        public static ErrorDto NoRoleException
        {
            get
            {
                return new ErrorDto(8, "نقش نسبت داده شده به کاربر در سیستم وجود ندارد");
            }
        }

        /// <summary>
        /// شماره موبایل وارد شده نا معتبر است 9
        /// </summary>
        public static ErrorDto InvalidMobileNumberException
        {
            get
            {
                return new ErrorDto(9, "شماره موبایل وارد شده نا معتبر است");
            }
        }

        /// <summary>
        /// شماره موبایل وارد شده قبلا در سیستم ثبت شده است 10
        /// </summary>
        public static ErrorDto DuplicateMobileUserException
        {
            get
            {
                return new ErrorDto(10, "شماره موبایل وارد شده قبلا در سیستم ثبت شده است");
            }
        }

        /// <summary>
        /// نام کاربری وارد شده تکراری است 11
        /// </summary>
        public static ErrorDto DuplicateUserException
        {
            get
            {
                return new ErrorDto(11, "نام کاربری وارد شده تکراری است");
            }
        }

        /// <summary>
        /// ورودی نا معتبر است 12
        /// </summary>
        public static ErrorDto InValidInputsException
        {
            get
            {
                return new ErrorDto(12, "ورودی نا معتبر است");
            }
        }

        /// <summary>
        /// اطلاعات پروفایل یافت نشد 13
        /// </summary>
        public static ErrorDto NotFoundProfileInfoException
        {
            get
            {
                return new ErrorDto(13, "اطلاعات پروفایل یافت نشد");
            }
        }

        /// <summary>
        /// فایلی جهت آپلود وجود ندارد 14
        /// </summary>
        public static ErrorDto FileIsNullException
        {
            get
            {
                return new ErrorDto(14, "فایلی جهت آپلود وجود ندارد");
            }
        }

        /// <summary>
        /// دسترسی غیر مجاز 15
        /// </summary>
        public static ErrorDto AccessDeniedException
        {
            get
            {
                return new ErrorDto(15, "دسترسی غیر مجاز");
            }
        }

        /// <summary>
        /// محصول مورد نظر یافت نشد 16
        /// </summary>
        public static ErrorDto NotFoundProductException
        {
            get
            {
                return new ErrorDto(16, "محصول مورد نظر یافت نشد");
            }
        }

        /// <summary>
        /// اطلاعات مشتری یافت نشد 17
        /// </summary>
        public static ErrorDto NotFoundCustomerException
        {
            get
            {
                return new ErrorDto(17, "اطلاعات مشتری یافت نشد");
            }
        }

        /// <summary>
        /// اطلاعات کاربری یافت نشد 18
        /// </summary>
        public static ErrorDto NotFoundUserException
        {
            get
            {
                return new ErrorDto(18, "اطلاعات کاربری یافت نشد");
            }
        }

        /// <summary>
        /// آدرس یافت نشد 19
        /// </summary>
        public static ErrorDto NotFoundAddressException
        {
            get
            {
                return new ErrorDto(19, "آدرس یافت نشد");
            }
        }

        /// <summary>
        /// دسته مورد نظر یافت نشد 20
        /// </summary>
        public static ErrorDto NotFoundCategoryException
        {
            get
            {
                return new ErrorDto(20, "دسته مورد نظر یافت نشد");
            }
        }


    }
}
