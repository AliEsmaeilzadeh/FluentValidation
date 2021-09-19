using Paraph_Food.Application.Services.Common.ErrorMessages;
using System;

namespace Paraph_Food.Application.Services.Common.Exceptions
{
    public class MyException : Exception
    {
        public MyException()
        {

        }
        public MyException(string message)
        {
            Code = -1;
            Message = message;
        }
        public MyException(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public MyException(MyException ex)
        {
            Code = ex.Code;
            Message = ex.Message;
        }
        public MyException(ErrorDto ex)
        {
            Code = ex.Code;
            Message = ex.Message;
        }
        public MyException(Exception ex)
        {
            Code = -1;
            Message = ex.Message;
        }


        public int Code { get; set; }
        public override string Message { get; }
    }
}
