using Paraph_Food.Application.Services.Common.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Common
{
    public class QueryResultDto<T> where T : class
    {
        public ErrorDto Exception { get; set; }
        public T Data { get; set; }
    }
}
