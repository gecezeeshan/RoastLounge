using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using FluentValidation.Results;

namespace Application.Common.Exceptions
{
   
  public class ValidationException : Exception, ISerializable
  {
     public IDictionary<string,string[]> Errors {get;}
    public ValidationException(): base("one or mre validation failures"){
        Errors  = new Dictionary<string,string[]>();

    }

    public ValidationException(IEnumerable<ValidationFailure> failures): this(){
        Errors  = new Dictionary<string,string[]>();

    }

  }

}