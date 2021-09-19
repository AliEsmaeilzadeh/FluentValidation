using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraph_Food.Application.Services.Common.InEnum
{
    public static class EnumChecker
    {
        public static bool InEnum(this object value, Type enumType)
        {
            if (enumType.IsEnum)
            {
                var enumValues = Enum.GetValues(enumType);

                foreach (var enumValue in enumValues)
                {
                    if (value.Equals(enumValue))
                        return true;
                }
            }
            return false;
        }
    }
}
