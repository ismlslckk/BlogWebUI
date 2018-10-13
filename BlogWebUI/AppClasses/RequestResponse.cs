using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.AppClasses
{
    public class RequestResponse
    { 
        public bool IsError { get; set; }
        public string Message { get; set; }
        public object data { get; set; }


        public void Ok(string message)
        {
            Message = message;
            IsError = false;
        }

        public void Error(string message)
        {
            Message = message;
            IsError=true;
        }
    }
}
