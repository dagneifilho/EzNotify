using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Validation
{
    public class ValidationAttributes
    {
        [AttributeUsage(AttributeTargets.Property | 
        AttributeTargets.Field, AllowMultiple = false)]
        sealed public class ListEmailAddress : ValidationAttribute
        {
            public bool Required {get;set;}
            public override bool IsValid(object? value)
            {
                var input = value as string;
                if(string.IsNullOrEmpty(input) && Required)
                    return false;
                
                if(!string.IsNullOrEmpty(input)){
                    EmailAddressAttribute emailAddressAttribute = new();
                    var emailList = input.Split(",");
                    foreach( var item in emailList ){
                        if(!emailAddressAttribute.IsValid(item))
                            return false;
                    }
                }
                return true;
            }
        }
    }
}