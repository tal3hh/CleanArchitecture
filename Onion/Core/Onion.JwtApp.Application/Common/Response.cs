using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Common
{
    public class Response : IResponse
    {
        public Response(string statusCode)
        {
            StatusCode = statusCode;
        }

        public Response(string statusCode,string message) : this(statusCode)
        {
            Message = message;
        }

        public string? Message { get; set; }
        public string? StatusCode { get; set; }
    }
}
