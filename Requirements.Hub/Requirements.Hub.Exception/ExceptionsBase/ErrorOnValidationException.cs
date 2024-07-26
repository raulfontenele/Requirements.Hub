using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : RequirementHubException
    {
        public ErrorOnValidationException(string? message) : base(message)
        {
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
