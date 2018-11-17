using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public class ValidationError
    {
        public ValidationError(string property, string message)
        {
            Property = property;
            Message = message;
        }
        public string Property { get; set; }
        public string Message { get; set; }
    }
}
