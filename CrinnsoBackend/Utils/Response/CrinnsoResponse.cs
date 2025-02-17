using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Response
{
    public class CrinnsoResponse<T> : ICrinnsoResponse<T>
    {
        public HttpStatusCode HttpCode { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public void SetSuccess(T result, string message = "OK")
        {
            HttpCode = HttpStatusCode.OK;
            HasError = false;
            Message = message;
            Result = result;
        }

        public void SetError(Exception exception)
        {
            HttpCode = HttpStatusCode.InternalServerError;
            HasError = true;
            Message = exception.Message;
            Result = default;
        }

        public void SetError(string message)
        {
            HttpCode = HttpStatusCode.InternalServerError;
            HasError = true;
            Message = message;
            Result = default;
        }
    }
}
