using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Response
{
    public interface ICrinnsoResponse<T>
    {
        bool HasError { get; set; }
        HttpStatusCode HttpCode { get; set; }
        string Message { get; set; }
        T Result { get; set; }
        void SetError(Exception exception);
        void SetError(string message);
        void SetSuccess(T result, string message = "OK");
    }
}
