using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCompare.Domain.Validations
{
    public class DomainValidationExceptions : Exception
    {
        public DomainValidationExceptions(string error) : base(error){}
        public static void When(bool hasError, string error)
        {
            if (hasError) 
            {
                throw new DomainValidationExceptions(error);
            }
        } 
    }
}