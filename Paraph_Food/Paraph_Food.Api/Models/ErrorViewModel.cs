using Paraph_Food.Application.Services.Common.Exceptions;
using System;

namespace Paraph_Food.Api.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {

        }
        public ErrorViewModel(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public ErrorViewModel(MyException ex)
        {
            Code = ex.Code;
            Message = ex.Message;
        }
        public ErrorViewModel(Exception ex)
        {
            Code = -1;
            Message = ex.Message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
