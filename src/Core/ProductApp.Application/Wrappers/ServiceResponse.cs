using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Wrappers
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }

        public ServiceResponse(T value)
        {
            this.Value = value;
            IsSuccess = true;
        }

        public ServiceResponse()
        {

        }
    }
}
