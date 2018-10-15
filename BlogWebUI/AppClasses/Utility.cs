using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.AppClasses
{
    public static class Utility
    {
        public static RequestResponse _requestResponse { get; set; }


        public static RequestResponse OkResponse(object message)
        {
            if (_requestResponse == null)
                _requestResponse = new RequestResponse();
            _requestResponse.Ok(message);
            return _requestResponse;
        }

        public static void SetData(object data)
        {
            _requestResponse.SetData(data);
        }


        public static RequestResponse ErrorResponse(object message)
        {
            if (_requestResponse == null)
                _requestResponse = new RequestResponse();
            _requestResponse.Error(message);
            return _requestResponse;
        }
    }
}
