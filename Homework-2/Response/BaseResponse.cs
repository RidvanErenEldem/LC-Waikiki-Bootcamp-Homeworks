using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Response
{
    public class BaseResponse
    {
        public bool success {get; set; }
        public string message {get; set; }
        protected BaseResponse(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }
    }
}