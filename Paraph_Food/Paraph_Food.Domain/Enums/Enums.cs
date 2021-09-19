using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enums
{
    public class Enums
    {
        public enum UserStatus
        {
            /// <summary>
            /// تایید شده
            /// </summary>
            Confirmed = 1,
            /// <summary>
            /// مسدود شده
            /// </summary>
            Blocked = 2,
            /// <summary>
            /// غیر فعال شده
            /// </summary>
            Disabled = 3,
        }

        public enum DiscountValueType
        {
            /// <summary>
            /// درصد
            /// </summary>
            Percent = 1,
            /// <summary>
            /// واحد پولی
            /// </summary>
            Currency = 2,
        }
    }
}
