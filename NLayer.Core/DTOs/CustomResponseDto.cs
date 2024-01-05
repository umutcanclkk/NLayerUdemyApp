using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }


        public List<string> Errors { get; set; }


        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> {StatusCode = statusCode };
        }


        public static CustomResponseDto<T> FailBadRequest(string error)
        {
            return new CustomResponseDto<T> { StatusCode = 400, Errors = new List<string> { error } };
        }

        public static CustomResponseDto<T> FailNotFound(string error)
        {
            return new CustomResponseDto<T> { StatusCode = 404, Errors = new List<string> { error } };
        }


                public static CustomResponseDto<T> Fail(int statusCode, string errors)
                {
                    return new CustomResponseDto<T> { StatusCode = statusCode, Errors= new List<string> { errors } };
                }


        public static CustomResponseDto<T> FailInternalServerError(string error)
        {
            return new CustomResponseDto<T> { StatusCode = 500, Errors = new List<string> { error } };
        }

        

    }
}


//using System.Text.Json.Serialization;

//namespace NLayer.Core.DTOs
//{
//    public class CustomResponseDto<T>
//    {
//        public T Data { get; set; }

//        [JsonIgnore]
//        public int StatusCode { get; set; }

//        public List<string> Errors { get; set; }

//        public static CustomResponseDto<T> Success(int statusCode, T data)
//        {
//            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
//        }

//        public static CustomResponseDto<T> Success(int statusCode)
//        {
//            return new CustomResponseDto<T> { StatusCode = statusCode };
//        }

//        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
//        {
//            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
//        }

//        public static CustomResponseDto<T> FailBadRequest(List<string> errors)
//        {
//            return new CustomResponseDto<T> { StatusCode = 400, Errors = errors };
//        }

//        public static CustomResponseDto<T> FailNotFound(List<string> errors)
//        {
//            return new CustomResponseDto<T> { StatusCode = 404, Errors = errors };
//        }

//        public static CustomResponseDto<T> FailInternalServerError(List<string> errors)
//        {
//            return new CustomResponseDto<T> { StatusCode = 500, Errors = errors };
//        }
//    }
//}





