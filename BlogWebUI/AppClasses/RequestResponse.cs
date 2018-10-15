using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.AppClasses
{
    public class RequestResponse
    {
        public bool IsError { get; set; }
        public object Message { get; set; }
        public object data { get; set; }


        public void Ok(object message)
        {
            Message = message;
            IsError = false;
        }

        public void SetData(object data)
        {
            this.data = data;
        }


        public void Error(object message)
        {
            Message = message;
            IsError = true;
        }
    }
}
