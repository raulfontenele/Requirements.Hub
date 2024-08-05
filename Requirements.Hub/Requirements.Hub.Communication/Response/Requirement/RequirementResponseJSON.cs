using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Communication.Response.Requirement
{
    public class RequirementResponseJSON
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Funcionality { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
    }
}
