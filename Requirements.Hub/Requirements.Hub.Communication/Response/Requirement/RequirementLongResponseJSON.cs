using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Communication.Response.Requirement
{
    public class RequirementLongResponseJSON
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Funcionality { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public Guid ProjectId { get; set; }
    }
}
