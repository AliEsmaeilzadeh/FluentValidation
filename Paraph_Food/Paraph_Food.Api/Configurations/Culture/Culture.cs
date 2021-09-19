using Paraph_Food.Application.Services.Common.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Configurations.Culture
{
    public static class Culture
    {
        private static CultureInfo _defaultCulture;
        public static CultureInfo GetDefaultCulture
        {
            get
            {
                return _defaultCulture = _defaultCulture ?? JalaliDateTime.GetPersianCulture();
            }
        }
    }
}
