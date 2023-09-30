using System;
using System.Collections.Generic;
using System.Text;

namespace CalenderApiBLL.Classes
{
    public class ErrorResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public string instance { get; set; }

        public List<ValidationError> validationErrors { get; set; }
    }
}
