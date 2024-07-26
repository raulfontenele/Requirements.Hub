using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Exceptions.ExceptionsBase
{
    public abstract class RequirementHubException : SystemException
    {
        public RequirementHubException(string? message) : base(message)
        {
        }
        public abstract HttpStatusCode GetStatusCode();
    }
}
