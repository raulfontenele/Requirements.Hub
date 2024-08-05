using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Requirements.Hub.Communication.Enums;

namespace Requirements.Hub.Communication.Request.Requirement
{
    public class UpdateRequirementRequestJSON
    {
        public string Description { get; set; } = string.Empty;
        public RequirementPriority Priority { get; set; }
    }
}
