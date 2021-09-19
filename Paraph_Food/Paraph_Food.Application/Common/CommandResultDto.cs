using Paraph_Food.Application.Services.Common.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Common
{
    public class CommandResultDto
    {
        public long? Id { get; set; }
        public bool IsSuccess { get; set; }
        public ErrorDto Exception { get; set; }
    }
}
