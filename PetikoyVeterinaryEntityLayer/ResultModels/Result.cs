using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetikoyVeterinaryEntityLayer.ResultModels
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Result()
        {
            
        }
        public Result(bool success)
        {
            IsSuccess = success;
        }

        public Result(bool success,string message) : this(success) 
        {
            Message = message;            
        }

    }
}
