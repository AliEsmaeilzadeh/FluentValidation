using Paraph_Food.Application.Services.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Common.ErrorMessages
{
    public class ErrorDto
    {
        public ErrorDto(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public ErrorDto(string message)
        {
            Code = -1;
            Message = message;
        }
        public ErrorDto(Exception ex)
        {
            Code = -1;
            Message = ex.Message;
        }
        public ErrorDto(MyException ex)
        {
            Code = ex.Code;
            Message = ex.Message;
        }



        public int Code { get; set; }
        public string Message { get; set; }
    }
}
