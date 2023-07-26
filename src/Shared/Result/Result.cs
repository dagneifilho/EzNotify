using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Result
{
    public abstract class Result <T> 
    {
        
        public T? Data {get;  set;}
        public int StatusCode {get;  set;}
        public ResultType ResultType{get;  set;}
    }

    public class CreatedResult<T> : Result<T> 
    {
        public CreatedResult( T? data ){
            Data = data;
            StatusCode = 201;
            ResultType = ResultType.CreatedResult;
        }
    }
    public class BadRequestResult<T> : Result<T> 
    {
        public BadRequestResult( T? data ){
            Data = data;
            StatusCode = 400;
            ResultType = ResultType.CreatedResult;
        }
    }
}