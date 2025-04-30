using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebDomain
{
    public class ResponsePayment<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public ResponsePayment()
        {
        }

        public ResponsePayment(int statusCode, bool success, string msg, T data)
        {
            Data = data;
            Succeeded = success;
            StatusCode = statusCode;
            Message = msg;
        }

        public static ResponsePayment<T> Fail(string errorMessage, int statusCode = 404)
        {
            return new ResponsePayment<T> { Succeeded = false, Message = errorMessage, StatusCode = statusCode };
        }
        public static ResponsePayment<T> Success(string successMessage, T data, int statusCode = 200)
        {
            return new ResponsePayment<T> { Succeeded = true, Message = successMessage, Data = data, StatusCode = statusCode };
        }
    }
}
