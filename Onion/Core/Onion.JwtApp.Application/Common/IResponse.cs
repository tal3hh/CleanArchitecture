using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Common
{
    public interface IResponse
    {
        string? Message { get; set; }
        string? StatusCode { get; set; }
    }
}
