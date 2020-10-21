using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spring_petclinic_customers_api
{
  public class ResourceNotFoundException: Exception
  {
    public ResourceNotFoundException()
    {
    }
    public ResourceNotFoundException(string message) : base(message)
    {
    }
    public ResourceNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
  }
}
