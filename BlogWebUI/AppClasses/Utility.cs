using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.AppClasses
{
    public static class Utility
    {
        public static RequestResponse _requestResponse { get; set; }


        public static RequestResponse OkResponse(string message)
        {
            if (_requestResponse == null)
                _requestResponse = new RequestResponse();
            _requestResponse.Ok(message);
            return _requestResponse;
        }

        public static RequestResponse ErrorResponse(string message)
        {
            if (_requestResponse == null)
                _requestResponse = new RequestResponse();
            _requestResponse.Error(message);
            return _requestResponse;
        }
    }
}
