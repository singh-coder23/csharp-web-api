using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercise.DTO
{
    public class Response
    {
        public string Message { get; set; }

        public bool Status { get; set; }

        public dynamic Data { get; set; }
    }
}
