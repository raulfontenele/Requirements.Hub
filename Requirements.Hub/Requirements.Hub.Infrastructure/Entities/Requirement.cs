using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Infrastructure.Entities
{
    public class Requirement
    {
        public Guid Id { get; set; } = new Guid();
        public string Description { get; set; } = string.Empty;
        public string Funcionality { get; set; } = string.Empty;
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public RequirementPriority Priority { get; set; }


    }
}
