using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Common
{
    public class Response<T> : Response, IResponse<T>
    {
        public Response(string statusCode, T data) : base(statusCode)
        {
            Data = data;
        }

        public Response(string statusCode,T data, string message) : base(statusCode,message)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
