using Requirements.Hub.Communication.Response.Requirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Communication.Response.Project
{
    public class ProjectLongResponseJson
    {
        public string Name { get; set; }
        public IList<RequirementResponseJSON> Requirements { get; set; }
    }
}
